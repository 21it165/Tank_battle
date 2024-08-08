using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    public Text PlayerKills;
    public Player_Health Player;
    private float EnemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        print(Player.Kills);
    }

    private void GetDamage(float Amount){
        EnemyHealth = EnemyHealth - Amount;
    }

    private void OnCollisionEnter(Collision collision){
        GameObject hitObj = collision.gameObject;
        if(hitObj.GetComponent<Player_Missile>()){
            GetDamage(hitObj.GetComponent<Player_Missile>().Damage);
        }
        if(EnemyHealth <= 0f){
             Player.Kills += 1;
             
            PlayerKills.text = Player.Kills.ToString();
           
            Destroy(gameObject);
        }
    }
}
