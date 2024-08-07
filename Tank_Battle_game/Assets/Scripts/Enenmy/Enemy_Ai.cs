using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ai : MonoBehaviour
{
    public Transform thePlayer;
    public float enemySpeed = 0.0000002f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer, Vector3.up);

        print(thePlayer);

        transform.position = Vector3.MoveTowards(transform.position, thePlayer.position, enemySpeed);
    }
}
