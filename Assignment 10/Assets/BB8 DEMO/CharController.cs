using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 25.0f;
    public float rotationSpeed = 90;
    public float force = 700f;
    public float walkSpeed = 1.5f;
    public GameObject leftArm;
    public GameObject rightArm;
    public GameObject friendsLeftArm;
    public GameObject friendsRightArm;

    Rigidbody rb;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                t.Translate(Vector3.forward * speed  * Time.deltaTime);
            }
            else
            {
                t.Translate(Vector3.forward * speed * walkSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.S))
            t.Translate(Vector3.back * speed * walkSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
            else
                t.rotation *= Quaternion.Euler(0, rotationSpeed * walkSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
            else
                t.rotation *= Quaternion.Euler(0, -rotationSpeed * walkSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            leftArm.transform.eulerAngles = new Vector3(40, leftArm.transform.eulerAngles.y, leftArm.transform.eulerAngles.z);
            friendsLeftArm.transform.eulerAngles = new Vector3(40, friendsLeftArm.transform.eulerAngles.y, friendsLeftArm.transform.eulerAngles.z);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            rightArm.transform.eulerAngles = new Vector3(40, rightArm.transform.eulerAngles.y, rightArm.transform.eulerAngles.z);
            friendsRightArm.transform.eulerAngles = new Vector3(40, friendsRightArm.transform.eulerAngles.y, friendsRightArm.transform.eulerAngles.z);
        }

        if (Input.GetKeyUp(KeyCode.N))
        {
            leftArm.transform.eulerAngles = new Vector3(0, leftArm.transform.eulerAngles.y, leftArm.transform.eulerAngles.z);
            friendsLeftArm.transform.eulerAngles = new Vector3(0, friendsLeftArm.transform.eulerAngles.y, friendsLeftArm.transform.eulerAngles.z);
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            rightArm.transform.eulerAngles = new Vector3(0, rightArm.transform.eulerAngles.y, rightArm.transform.eulerAngles.z);
            friendsRightArm.transform.eulerAngles = new Vector3(0, friendsRightArm.transform.eulerAngles.y, friendsRightArm.transform.eulerAngles.z);
        }
    }
}