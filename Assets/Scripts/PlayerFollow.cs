using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Player;

    bool isFollowing = true;
    bool isPlayerInRange = false;

    public Vector3 initialDetectionSize = new Vector3(5, 1, 6);
    public Vector3 newDetectionSize = new Vector3(7, 1, 8);
    public BoxCollider detectionRadius;
    // Start is called before the first frame update
    void Start()
    {
        if(detectionRadius != null)
        {
            detectionRadius.size = initialDetectionSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && isFollowing && Player != null)
        {
            detectionRadius.size = newDetectionSize;
            transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, 8f * Time.deltaTime);
        }
        else
        {
            detectionRadius.size = initialDetectionSize;
        }
    }
    public void stopFollowing()
    {
        isFollowing = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;//player has entered the raidus
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange= false;//player is not in radius
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<PlayerMovement>().PlayerDamage();
        }
    }
}
