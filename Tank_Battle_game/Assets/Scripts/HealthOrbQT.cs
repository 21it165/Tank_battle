using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrbQT : MonoBehaviour
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
            HitObj.GetComponent<Player_Health>().Health = 100f;
            HitObj.GetComponent<Player_Health>().HealDisplay.text = 100.ToString();
            Destroy(gameObject);
        }
    }
}
