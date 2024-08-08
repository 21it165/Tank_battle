using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turet_Movement : MonoBehaviour
{
    public float Sensi;

    private float mouseX;

    private float Mouse_pos;
    
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {

        
        Vector3 Turet_Rot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        //Vector3 Turet_Rot = new Vector3((float)transform.parent.rotation.x * 116.8729, transform.rotation.y, (float)transform.parent.rotation.z * 177.483);

        //print(Turet_Rot);

        mouseX = Input.GetAxisRaw("Mouse X") * Sensi * Time.deltaTime;

        Mouse_pos += mouseX; 
        
        //Turet_Rot.y = Mathf.Clamp(Mouse_pos, 0f, 359f);
        Turet_Rot.y = Mouse_pos;

        Quaternion Turet_Rot_Quternion = Quaternion.Euler(Turet_Rot.x, Turet_Rot.y, Turet_Rot.z);
    
        transform.rotation = Turet_Rot_Quternion; 
        //transform.rotation = new Vector3(Turet_Rot.x, 0f, Turet_Rot.z);
    }
}
