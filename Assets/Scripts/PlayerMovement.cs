using System;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{
    float moveX;
    float moveZ;
    float moveSpeed=15f;
    public float maxHealth = 100f;
    private float currentHealth;
    //public CharacterController Player;
    public Camera mainCamera;
    public GameObject enemyCube;

    // Start is called before the first frame update
    void Start()
    {
        if(mainCamera == null)
        {
            mainCamera = GetComponentInChildren<Camera>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        //Player.Move(move*moveSpeed*Time.deltaTime);
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }

    public void PlayerDamage()
    {
        if(maxHealth > 0)
        {
            maxHealth -= 10;
            Debug.Log(maxHealth);
        }
        if(maxHealth <= 0)
        {
            if (mainCamera != null)
            {
                mainCamera.transform.SetParent(null); // Detach the camera to keep it active
                mainCamera.gameObject.SetActive(true);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {       
        // Deactivate the player
        if (other.gameObject.CompareTag("Obstacle"))
        {
            
            if (mainCamera != null)
            {
                mainCamera.transform.SetParent(null); // Detach the camera to keep it active
                mainCamera.gameObject.SetActive(true);
            }
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if(enemyCube != null)
        {
            PlayerFollow playerFollowScript = enemyCube.GetComponent<PlayerFollow>();
            if(playerFollowScript != null)
            {
                playerFollowScript.stopFollowing();
            }
        }
    }

}
