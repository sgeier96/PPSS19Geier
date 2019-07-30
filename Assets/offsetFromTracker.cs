using System;
using UnityEngine;
using Valve.VR;

public class offsetFromTracker : MonoBehaviour
{
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 translateVec = new Vector3(1.0f, 1.0f, 1.0f);
        //Vector3 pos = transform.position;
        //transform.position = pos - translateVec;
        transform.position = transform.position - translateVec;
        Debug.Log(transform.position);
    }
}
 