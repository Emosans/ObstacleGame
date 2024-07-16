using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Player;

    bool isFollowing = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing && Player != null)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, 5f * Time.deltaTime);
        }
        else
        {
            isFollowing = false;
        }
    }
}
