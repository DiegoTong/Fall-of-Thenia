using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Overworld : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject CenterPoint;

    public float turningSpeed = 0.1f;
    public float movementSpeed = 10.0f;   
    private Rigidbody rb;
    void Start()
    {
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 0.1f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.1f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.1f, 0, 0);
        }
        rb.AddForce (transform.position * movementSpeed);
    }

    void Update()
    {
        MovePlayer();
    }
    void OnTriggerEnter(Collider other)
    {
     //   if (other.gameObject.CompareTag("Pick Up"))
     //   {
      //      other.gameObject.SetActive(false);
     //   }
    }
}





//if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0)
//{
//    //turningSpeed += ((Input.GetAxis("Mouse X")) * Time.deltaTime * 5.0f);
//    transform.RotateAround(CenterPoint.transform.position, new Vector3(0, 0.1f, 0), turningSpeed);
//    print("Mouse moved");
//}