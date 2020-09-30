using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float x;
    private float y;
    private Vector3 rotation;
   
    void Update()
    {

        y = Input.GetAxis("Mouse Y");

        x = Input.GetAxis("Mouse X");

        rotation = new Vector3(0, x * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotation;

    }
}
