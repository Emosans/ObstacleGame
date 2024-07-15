using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{
    float moveX;
    float moveZ;
    float moveSpeed=15f;

    //public CharacterController Player;
    public Camera mainCamera;

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

    private void OnTriggerEnter(Collider other)
    {
        if (mainCamera != null)
        {
            mainCamera.transform.SetParent(null); // Detach the camera to keep it active
            mainCamera.gameObject.SetActive(true);
        }

        // Deactivate the player
        gameObject.SetActive(false);
    }


}
