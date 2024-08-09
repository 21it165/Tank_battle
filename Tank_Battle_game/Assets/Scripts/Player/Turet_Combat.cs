using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turet_Combat : MonoBehaviour
{
    
    public GameObject missile;
    //public Animator animator;
    public Transform FirePad;
    public KeyCode FireButon;
    private float Missile_Rload_Time = 1f;
    private bool CanFire;
    private Rigidbody rb_missile; 
    private float MissileForce = 1000f;
    private AudioSource FireSound;
    private Vector3 AimPoint;
    private Ray ray;
    private RaycastHit hit;
    private LineRenderer lineRenderer;
    private GameObject ToDestroyObj;
    
    // Start is called before the first frame update
    void Start()
    {
        CanFire = true;
        FireSound = GetComponent<AudioSource>();
        lineRenderer = FirePad.GetComponent<LineRenderer>();
        //lineRenderer.SetPosition(0, FirePad.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        lineRenderer.SetPosition(0, FirePad.position);
        ray = new Ray(FirePad.position, FirePad.forward);
        
        Physics.Raycast(ray, out hit, 500f);
        AimPoint = hit.point;
         lineRenderer.SetPosition(1, AimPoint);
        if(Input.GetKeyDown(FireButon) && CanFire){
            //Invoke("Fire", Missile_Rload_Time);
            StartCoroutine(Fire());
        }
        Debug.DrawRay(FirePad.position, FirePad.forward * 500f, Color.red);
        
    }

    IEnumerator Fire(){
        CanFire = false;
        

        FireSound.Play();
        //animator.SetTrigger("FireTrigger");

        //Vector3 ForceDirection = FirePad.forward;
       
        

         
            GameObject Projectile = Instantiate(missile, FirePad.position, Quaternion.identity);
             rb_missile = Projectile.GetComponent<Rigidbody>();
            Vector3 ForceDirection = (hit.point - FirePad.position).normalized;
            rb_missile.AddForce(ForceDirection * MissileForce, ForceMode.Impulse);
            //ToDestroyObj = GameObject.FindGameObjectWithTag("ExplotionObj");
            //missile.GetComponent<Player_Missile>().ExplotionPoint = hit.point;
           // print(hit.point);
         
           
          

        //Vector3 ForaceToAdd = ForceDirection * MissileForce + transform.up * 100f;

        //print(ForaceToAdd);
        

        

        //rb_missile.velocity = transform.forward * 100f;

        yield return new WaitForSeconds(Missile_Rload_Time);
         Destroy(ToDestroyObj);
        CanFire = true;
    }

    public void SetToDestroyObj(GameObject obj){
        ToDestroyObj = obj;
    }

}
