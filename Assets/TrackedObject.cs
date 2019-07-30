using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


[RequireComponent(typeof(SteamVR_TrackedObject))]
public class TrackedObject : MonoBehaviour
{
    public SteamVR_TrackedObject steamVR_trackedObj;
    void Start()
    {
        string[] connectedJoystickNames = UnityEngine.Input.GetJoystickNames();

        Debug.Log(connectedJoystickNames);
    }
}
