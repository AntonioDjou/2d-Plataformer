using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D enemyRigidbody;
    Vector3 movement;

    void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.Set(-3,0,0);
        enemyRigidbody.MovePosition (transform.position + movement * Time.deltaTime);
    }
}
