using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;
    public float duration = 4f;
    public GameObject powerUpGraphics;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider other)
    {
        Debug.Log("Power up picked up");

        PlayerMovement health = other.GetComponent<PlayerMovement>();
        health.maxHealth *= multiplier;

        powerUpGraphics.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        health.maxHealth /= multiplier;

        Destroy(gameObject);
    }
}
