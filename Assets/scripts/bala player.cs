using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaplayer : MonoBehaviour
{
    [Header("tiempo de vida")]
    public float dieTime;

    [Header("tag")]
    public string tag;

    private void Start()
    {
        Invoke("destruir", dieTime);
    }

    public void destruir()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            Destroy(gameObject);
        }
    }
}
