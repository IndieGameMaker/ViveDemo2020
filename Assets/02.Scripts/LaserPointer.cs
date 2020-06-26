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

    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = SteamVR_Input_Sources.LeftHand;
        teleport = SteamVR_Actions.default_Teleport;
        
        pointerPrefab = Resources.Load<GameObject>("Pointer");
        pointer = Instantiate<GameObject>(pointerPrefab, this.transform);

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

}
