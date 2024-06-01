using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [Header("movimiento")]
    public float speed;
    public Vector2 move;

    [Header("disparo")]
    public Transform lanzallama;
    public GameObject fuego;

    [Header("vida")]
    public int totalHP;
    public int HP;
    public void onMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void onShoot(InputAction.CallbackContext context)
    {       
        var bullet = Instantiate(fuego, lanzallama.position, fuego.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = lanzallama.transform.forward * speed;
    }

    private void Update()
    {
        //movimiento
        MovePlayer();

        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.transform.position.y;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        Vector3 direction = mouseWorldPosition - transform.position;
        direction.y = 0; 

        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = rotation;

        //vida
        if(HP >= totalHP)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void MovePlayer()
    {
        //movimiento
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tiro enemigo"))
        {
            HP++;
        }
    }
}
