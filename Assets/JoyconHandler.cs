using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconHandler : MonoBehaviour
{

    private List<Joycon> joycons;

    //Values made available via Unity
    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public int joyconIndex = 0;
    public Quaternion orientation;

    //Rumble variables
    //For more information see:
    //https://github.com/dekuNukem/Nintendo_Switch_Reverse_Engineering/blob/master/rumble_data_table.md

   [Header("Rumble settings")]
    public int lowFrequency; //Hz
    public int highFrequency; //Hz
    public float amplitude = 0.6f; //stronger or weaker feeling vibration
    public int rumbleDuration; //in milliseconds

    // Start is called before the first frame update
    void Start()
    {
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        //get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
        if(joycons.Count < joyconIndex + 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //make sure the Joycon only gets checked if attached
        if(joycons.Count > 0)
        {
            Joycon joycon = joycons[joyconIndex];
            //GetButtonDown checks if a button has been pressed (not held)
            if (joycon.GetButtonDown(Joycon.Button.SHOULDER_1))
            {
                Debug.Log("Shoulder button 1 pressed");
                joycon.SetRumble(0, 0, 0);
            }
            if (joycon.GetButtonDown(Joycon.Button.SHOULDER_2))
            {
                Debug.Log("Shoulder button 2 pressed");

                //Joycon has no magnetometer, so it cannot accurately determine its yaw value. 
                //Joycon.Recenter allows the user to reset the yaw value.
                joycon.Recenter();
                Debug.Log("Joycon recentered");
            }
            if (joycon.GetButtonDown(Joycon.Button.DPAD_UP))
            {
                Debug.Log("DPad_up or X button pressed");
            }
            if (joycon.GetButtonDown(Joycon.Button.DPAD_RIGHT))
            {
                Debug.Log("DPad right or A button pressed");
            }
            if (joycon.GetButtonDown(Joycon.Button.DPAD_DOWN))
            {
                Debug.Log("DPad_down or B button pressed");
            }
            if (joycon.GetButtonDown(Joycon.Button.DPAD_LEFT))
            {
                Debug.Log("DPad left or Y button pressed");
            }
            if (joycon.GetButtonDown(Joycon.Button.HOME))
            {
                Debug.Log("Home button pressed");
            }
            if (joycon.GetButtonDown(Joycon.Button.PLUS))
            {
                Debug.Log("Plus button pressed");
                Debug.Log("Rumble");

                if(rumbleDuration > 0)
                {
                    joycon.SetRumble(lowFrequency, highFrequency, amplitude, rumbleDuration);
                }
                else
                {
                    joycon.SetRumble(lowFrequency, highFrequency, amplitude);
                }

                // The last argument (time) in SetRumble is optional. 
                // Call it with three arguments to turn it on without telling it when to turn off.
                // (Useful for dynamically changing rumble values.)
                // Then call SetRumble(0,0,0) when you want to turn it off.
            }
            if (joycon.GetButtonDown(Joycon.Button.STICK))
            {
                Debug.Log("Stick pressed");
            }
            if (joycon.GetButtonDown(Joycon.Button.SR))
            {
                Debug.Log("SR button pressed");
            }
            if (joycon.GetButtonDown(Joycon.Button.SL))
            {
                Debug.Log("SL button pressed");
            }
            

            stick = joycon.GetStick();

            //Gyro values: x, y, z axis values (in radians per second)
            gyro = joycon.GetGyro();

            //Accel values: x, y, z axis values (in Gs)
            accel = joycon.GetAccel();

            orientation = joycon.GetVector();
            orientation *= Quaternion.Euler(Vector3.right * 180);
            orientation = new Quaternion(-orientation.x, orientation.y, orientation.z, orientation.w);
            gameObject.transform.localRotation = Quaternion.Inverse(orientation);

            gameObject.transform.rotation = orientation;

            if (accel.magnitude > 0)
            {
                gameObject.transform.Translate(accel * Time.deltaTime);
            }
        }
    }
}
