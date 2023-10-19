using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool player1 = true;

    [Header("Movement")]
    public float speed = 10;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public float fireRate = 1;
    public Transform firePoint;

    [Header("Audio")]
    public AudioSource audioSource; 
    public AudioClip Moving; 

    private bool isMoving = false; 

    private void Start()
    {
        InvokeRepeating(nameof(Shoot), fireRate, fireRate);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }

    void Update()
    {
        var direction = new Vector3();

        if (player1)
        {
            direction.x = Input.GetAxis("Horizontal");
            direction.z = Input.GetAxis("Vertical");

        }
        else
        {
            direction.x = Input.GetAxis("Horizontal2");
            direction.z = Input.GetAxis("Vertical2");
        }

        transform.position += direction * speed * Time.deltaTime; //timeDeltatime - time beetwen frame

        if (direction != Vector3.zero)
        {
            transform.forward = direction; //if not working transform.right or transfrom.right = -direction
        }

        
        if (isMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = Moving;
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
        
    }
}
