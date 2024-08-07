using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Missile : MonoBehaviour
{
    public float Damage = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision){
        GameObject ColObj = collision.gameObject;

        if(!ColObj.GetComponent<Enemy_Health>()){
            Destroy(gameObject);
        }
    }
}
