using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Player;

    bool isFollowing = true;
    bool isPlayerInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && isFollowing && Player != null)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, 8f * Time.deltaTime);
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
}
