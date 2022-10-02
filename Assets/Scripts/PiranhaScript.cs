using UnityEngine;

public class PiranhaScript : MonoBehaviour
{
    Rigidbody2D enemyRigidbody;

    void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Mathf.Abs(enemyRigidbody.velocity.y) < 0.01f)
        {
           enemyRigidbody.AddForce(new Vector2(0f, 7.5f), ForceMode2D.Impulse);
        }
    }
}
