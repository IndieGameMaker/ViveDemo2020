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
    //트랙패드 관련 입력값 정의
    public SteamVR_Action_Boolean trackPadClick = SteamVR_Actions.default_Teleport;
    public SteamVR_Action_Boolean trackPadTouch = SteamVR_Actions.default_TrackPadTouch;
    public SteamVR_Action_Vector2 trackPadPosition = SteamVR_Actions.default_TrackPadPosition;

    private SteamVR_Action_Vibration haptic = SteamVR_Actions.default_Haptic;

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
            haptic.Execute(0.2f, 0.3f, 120.0f, 0.5f, leftHand);
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

        if (trackPadTouch.GetState(any))
        {
            Vector2 pos = trackPadPosition.GetAxis(any);
            Debug.Log($"Touch Pos x={pos.x}/y={pos.y}");  //C# 6.0
            //Debug.LogFormat("Touch Pos x={0}/y={1}", pos.x, pos.y)        
        }        
    }
}