using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Missile : MonoBehaviour
{
    public float Damage = 25f;
    public GameObject ExplotionObj;
    public Vector3 ExplotionPoint;
    private Turet_Combat turet_Combat;
    //private GameObject child;

    //private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        turet_Combat = FindObjectOfType<Turet_Combat>();
        //audioSource = GetComponent<AudioSource>();
        //GameObject child = transform.Find("Explotion").gameObject;
    }

   

    private void OnCollisionEnter(Collision collision){
        GameObject ColObj = collision.gameObject;
        //audioSource.Play();
        
        if(!ColObj.GetComponent<Player_Health>()){
            ExplotionPoint = transform.position;
            GameObject ExplotionObject = Instantiate(ExplotionObj, ExplotionPoint, Quaternion.identity);
            //child.SetActive(true);
            turet_Combat.SetToDestroyObj(ExplotionObject);
            Destroy(gameObject);
            
        }
    }
}
