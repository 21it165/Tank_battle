using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOrbQT : MonoBehaviour
{
   

     private void OnTriggerEnter(Collider collider){
        GameObject HitObj = collider.gameObject;

        if(HitObj.GetComponent<Player_Health>()){
            HitObj.GetComponent<Player_Health>().ShieldActive = true;
            HitObj.GetComponent<Player_Health>().ShielStratTime = Time.time;
            Destroy(gameObject);
        }
    }
}
