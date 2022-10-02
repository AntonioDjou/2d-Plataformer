using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 10f;           // Jumping Height
    public float movementSpeed = 6f;        // The speed that the player will move at.
    Rigidbody2D playerRigidbody;            // The Player's RigidBody used in Unity
    Vector3 direction;                      // The vector to store the direction of the player's movement.
    Animator anim;                          // Reference to the animator component.
    

    void Awake()
    {
        anim = GetComponent <Animator> ();
        playerRigidbody = GetComponent <Rigidbody2D> ();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && Mathf.Abs(playerRigidbody.velocity.y) < 0.01f) // Checks if the player is on the ground
        {
            playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Add a force to jump
        }

        var movement = Input.GetAxisRaw("Horizontal"); // Stores the keys pressed
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed; // Moves the player acording to the 

        Animating (movement); // For the movement Animation

        direction.Set (movement, 0f, 0f); // Gets the correct direction that the player is facing
        if(direction.x > 0) // If he's moving to the right
        {
            transform.eulerAngles = new Vector3(0,0,0); // The animation will be facing right
        }
        else if (direction.x < 0) // If he's facing left
        {
            transform.eulerAngles = new Vector3(0,180,0); // The sprite will rotate in Y axis to follow the movement
        }
    }

    void Animating (float movement) // For adding the running animation
    {
        bool walking = movement != 0f; // Create a boolean that is true if either of the input axes is non-zero.
        anim.SetBool ("IsWalking", walking); // Tell the animator whether or not the player is walking.
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("GameOver");
        }
        else if (collision.gameObject.tag == "NextStage")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("YouWin");
        }   
    }
}
