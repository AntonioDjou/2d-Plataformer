using UnityEngine;
using UnityEngine.SceneManagement;

public class SpacehipMovement : MonoBehaviour
{
    public float movementSpeed = 6f;        // The speed that the player will move at.
    Rigidbody2D playerRigidbody;            // The Player's RigidBody used in Unity

    void Awake()
    {
        playerRigidbody = GetComponent <Rigidbody2D> ();
    }

    void Update()
    {
        var movement = Input.GetAxisRaw("Horizontal"); // Stores the keys pressed
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed; // Moves the player acording to the 
    }
}