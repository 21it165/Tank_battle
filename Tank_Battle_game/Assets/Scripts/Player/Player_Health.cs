using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public Text HealDisplay;
    public int Kills;
    public float Health;
    public bool ShieldActive;
    public float ShielStratTime;

    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
        Kills = 0;
        ShieldActive = false;
        HealDisplay.text = Health.ToString();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame


    private void GetDamage(float Amount){
        Health = Health - Amount;
        HealDisplay.text = Health.ToString();
        if(Health <= 0f){
            Destroy(gameObject);
            levelManager.LoadLevel("GameOver");
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(Time.time - ShielStratTime >= 10f){
            ShieldActive = false;
        }
        GameObject hitObj = collision.gameObject;
        if(hitObj.GetComponent<Enemy_Missile>() && !ShieldActive){
            
            GetDamage(hitObj.GetComponent<Enemy_Missile>().Damage);
        }else if(hitObj.GetComponent<Enemy_Missile>() && ShieldActive){
            Destroy(hitObj);
        }
    }
}
