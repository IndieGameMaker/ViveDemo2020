using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabMgr : MonoBehaviour
{
    private SteamVR_Input_Sources hand = SteamVR_Input_Sources.Any;
    private SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;

    //컨트롤러로 잡은 물체를 저장할 변수
    private Transform grabObject;
    //공에 접촉했는지 여부
    private bool isTouched = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched && trigger.GetStateDown(hand))
        {
            grabObject.SetParent(this.transform);
            grabObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("BALL"))
        {
            isTouched = true;
            grabObject = coll.transform;
        }
    }
}
