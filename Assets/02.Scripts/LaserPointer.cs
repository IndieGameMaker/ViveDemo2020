using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private SteamVR_Action_Boolean teleport;

    //라인렌더러 속성 변수
    private LineRenderer line;
    [Range(3.0f, 10.0f)]
    public float distance = 5.0f;
    public Color defaultColor = Color.green;
    public Color clickedColor = Color.blue;

    [SerializeField]
    private GameObject pointerPrefab;
    private GameObject pointer;

    //Raycast
    private RaycastHit hit;
    private Transform tr;

    public float durationTime = 0.2f;


    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = SteamVR_Input_Sources.LeftHand;
        teleport = SteamVR_Actions.default_Teleport;
        
        pointerPrefab = Resources.Load<GameObject>("Pointer");
        pointer = Instantiate<GameObject>(pointerPrefab, this.transform);
        tr = GetComponent<Transform>();

        CreateLine();
    }

    void CreateLine()
    {
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0, 0, distance));

        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = defaultColor;

        line.startWidth = 0.05f;
        line.endWidth   = 0.005f;
    }

    void Update()
    {
        if (Physics.Raycast(tr.position, tr.forward, out hit, distance))
        {
            line.SetPosition(1, new Vector3(0, 0, hit.distance));
            pointer.transform.position = hit.point  + (hit.normal * 0.01f);
            pointer.transform.rotation = Quaternion.LookRotation(hit.normal); 
        }
        else
        {
            pointer.transform.position = tr.position + (tr.forward * distance);
            pointer.transform.rotation = Quaternion.LookRotation(tr.forward);
        }

        if (teleport.GetStateDown(hand) 
            && Physics.Raycast(tr.position, tr.forward, out hit, distance, 1<<8))
        {
            SteamVR_Fade.Start(Color.black, 0.0f);
            StartCoroutine(Teleport(hit.point));
        }
    }

    IEnumerator Teleport(Vector3 pos)
    {
        tr.parent.transform.position = pos;
        //Waiting
        yield return new WaitForSeconds(durationTime);
        SteamVR_Fade.Start(Color.clear, 0.2f);
    }
}
