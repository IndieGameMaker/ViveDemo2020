using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveController : MonoBehaviour
{
    //컨트롤러 정의
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources rightHand;
    public SteamVR_Input_Sources any; 

    //컨트롤러 입력값 정의
    public SteamVR_Action_Boolean trigger;
    //트랙패드 클릭
    public SteamVR_Action_Boolean trackPadClick = SteamVR_Actions.default_Teleport;

    void Awake()
    {
        trigger = SteamVR_Actions.default_InteractUI;
    }

    
    void Update()
    {
        //왼손 컨트롤러의 트리거 버튼을 클릭했을 때 발생
        if (trigger.GetStateDown(leftHand))
        {
            Debug.Log("Clicked Trigger Button");
        }

        //오른손 컨트롤러의 트리거 버튼을 릴리스했을 때 발생
        if (trigger.GetStateUp(rightHand))
        {
            Debug.Log("Released Trigger Button");
        }     
    
        //트랙패드 클릭
        if (trackPadClick.GetStateDown(any))
        {
            Debug.Log("TrackPad Click");
        }
    }
}
