using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostOrbQT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider){
        GameObject HitObj = collider.gameObject;

        if(HitObj.GetComponent<Player_Health>()){
            HitObj.GetComponent<Tank_Movement>().MovementSpeed = 25f;
            HitObj.GetComponent<Tank_Movement>().RotationSpeed = 25f;
            HitObj.GetComponent<Tank_Movement>().BoostStartTime = Time.time;
            Destroy(gameObject);
        }
    }
}
