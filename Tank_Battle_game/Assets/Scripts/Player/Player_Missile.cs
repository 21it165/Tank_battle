using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Missile : MonoBehaviour
{
    public float Damage = 25f;

    //private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision){
        GameObject ColObj = collision.gameObject;
        //audioSource.Play();

        if(!ColObj.GetComponent<Player_Health>()){
            Destroy(gameObject);
        }
    }
}
