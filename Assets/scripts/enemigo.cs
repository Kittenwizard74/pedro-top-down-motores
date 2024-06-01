using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    [Header("vida")]
    public int vidatotal;
    private int vida = 0;

    [Header("movimiento")]
    public float speed;
    public float minX;
    public float maxX;

    Rigidbody rb;
    gamemanager manager;
    public string ID;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = GameObject.Find("gameManager").GetComponent<gamemanager>();
    }

    void Update()
    {
        if (vida >= vidatotal)
        {
            Destroy(gameObject);
            manager.EnemyDefeated(ID);
        }
        Move();
    }

    void Move()
    {
        if (transform.position.x <= minX || transform.position.x >= maxX)
        {
            speed *= -1;
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tiro"))
        {
            vida++;
        }
    }
}
