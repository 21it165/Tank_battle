using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ai : MonoBehaviour
{
    // public Transform thePlayer;
    // public float enemySpeed = 0.0000002f;
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     transform.LookAt(thePlayer, Vector3.up);

    //     print(thePlayer);

    //     transform.position = Vector3.MoveTowards(transform.position, thePlayer.position, enemySpeed);
    // }

    public Transform player;         // Reference to the player's position
    public float moveSpeed = 10f;     // Speed at which the tank moves
    public float rotationSpeed = 10f; // Speed at which the tank rotates to face the player
    public float attackRange = 70f;  // Range within which the tank will start firing
    public float fireRate = 5f;      // Time between shots

    public GameObject bulletPrefab;  // Bullet prefab to fire
    public Transform firePoint;      // Point from where the bullets are fired

    private float LastFireTime = 0f;
    private AudioSource audioSource;
    private float bulletSpeed = 1000f;
    private bool CanFire;

    void Start(){
        CanFire = true;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player != null)
        {
            // Move towards the player
            MoveTowardsPlayer();

            // Rotate to face the player
            RotateTowardsPlayer();

            // Check if within attack range
            if (Vector3.Distance(transform.position, player.position) <= attackRange && CanFire)
            {
                moveSpeed = 0f;
                //rotationSpeed = 0f;
                // Fire at the player
                FireAtPlayer();
            }
            else{
                moveSpeed = 10f;
                //rotationSpeed = 10f;
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 movePosition = transform.position + direction * moveSpeed * Time.deltaTime;
        transform.position = movePosition;
    }

    void RotateTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void FireAtPlayer()
    {
        CanFire = false;
        if (Time.time - LastFireTime >= fireRate)
        {
            // Instantiate the bullet and fire it towards the player
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            // Add code here to set bullet direction and speed if needed
             bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * bulletSpeed;
             audioSource.Play();

            LastFireTime = Time.time;
        }
        CanFire = true;
    }
}
