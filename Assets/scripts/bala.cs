using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float bulletLife = 1f;
    //public float speed = 1f;
    //public float rotation = 0f;

    //private Vector3 spawnPoint;
    private float timer = 0f;

    private void Start()
    {
        //spawnPoint = new Vector2 (transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if (timer >= bulletLife) 
        { 
            Destroy (this.gameObject);
        }
        timer += Time.deltaTime;
        //transform.position = Movement(timer);
    }

    //private Vector2 Movement(float timer)
    //{
    //    //se mueve segun orientacion de la bala
    //    float x = timer * speed * transform.right.x;       
    //    float y = timer * speed * transform.right.y;

    //    return new Vector3(x+spawnPoint.x, y+spawnPoint.y);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
