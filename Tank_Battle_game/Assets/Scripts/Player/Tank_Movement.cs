using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour
{
    public float MovementSpeed;
    public float BoostStartTime;
    public float RotationSpeed;
    private float HorizontalInput;
    private float VericalInput;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time - BoostStartTime >= 15f){
            MovementSpeed = 15f;
            RotationSpeed = 15f;
        }
        Move();
        //print(MovementSpeed);
    }

    private void Move(){
        HorizontalInput = Input.GetAxis("Horizontal");
        VericalInput = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.W)){
            //rb.MovePosition(transform.position + new Vector3(0f, 0f, (VericalInput * MovementSpeed * Time.deltaTime)));
            //rb.velocity = new Vector3(0f, 0f, (VericalInput * MovementSpeed * Time.deltaTime));
            rb.MovePosition(transform.position + (transform.forward * VericalInput * MovementSpeed * Time.deltaTime));
        }
        else if(Input.GetKey(KeyCode.S)){
            //rb.MovePosition(transform.position + new Vector3(0f, 0f, (VericalInput * Time.deltaTime *((MovementSpeed*2)/3))));
            //rb.velocity = new Vector3(0f, 0f, (VericalInput * Time.deltaTime *((MovementSpeed*2)/3)));
            rb.MovePosition(transform.position + (transform.forward * VericalInput * MovementSpeed * Time.deltaTime));
            HorizontalInput = -(HorizontalInput);
        }

        Quaternion rbRotation = Quaternion.Euler(new Vector3(0f, HorizontalInput * RotationSpeed, 0f) * Time.deltaTime);
        if(Input.GetKey(KeyCode.A)){
            rb.MoveRotation(transform.rotation * rbRotation);
            //transform.Rotate(0f, HorizontalInput * RotationSpeed, 0f, Space.Self);
            
        }
        else if(Input.GetKey(KeyCode.D)){
            rb.MoveRotation(transform.rotation * rbRotation);
            //transform.Rotate(0f, HorizontalInput * RotationSpeed, 0f, Space.Self);
        }
    }
}
