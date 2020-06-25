using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private LineRenderer line;

    void Start()
    {
       hand = SteamVR_Input_Sources.LeftHand; 
    }

    void Update()
    {
        
    }
}
