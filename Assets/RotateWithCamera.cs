using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithCamera : MonoBehaviour
{
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        if (Camera.main != null) target = Camera.main.transform;
        else Debug.LogError(message: "Main Camera not found");
        Debug.Log(target);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
