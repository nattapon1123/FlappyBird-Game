using System;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    public GameManager gameManager;
    public Transform leftWing;
    public Transform rightWing;
    private Quaternion leftWingDefaultRotation;
    private Quaternion rightWingDefaultRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (leftWing != null && rightWing != null)
        {
            leftWingDefaultRotation = leftWing.localRotation;
            rightWingDefaultRotation = rightWing.localRotation;
        }
    }

    void Update()
    {
        if (!gameManager || !gameManager.isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                if (leftWing != null && rightWing != null)
                {
                    leftWing.localRotation = Quaternion.Euler(0, 0, 30f);
                    rightWing.localRotation = Quaternion.Euler(0, 0, -30f);

                    CancelInvoke(nameof(ResetWings)); 
                    Invoke(nameof(ResetWings), 0.15f); 
                }
            }
        }
    }

    void ResetWings()
    {
        leftWing.localRotation = leftWingDefaultRotation;
        rightWing.localRotation = rightWingDefaultRotation;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bird Hit: " + collision.gameObject.name);

        if (!gameManager.isGameOver)
        {
            if (collision.gameObject.CompareTag("Boundary") || collision.gameObject.CompareTag("Pipe"))
            {
                gameManager.GameOver();
            }
            Debug.Log("Calling GameOver()");
            gameManager.GameOver();
        }
    }

    internal void StartFlyIn()
    {
        Invoke(nameof(StopHorizontal), 2f);
    }

    void StopHorizontal()
    {
        rb.linearVelocity = Vector2.zero;
    }
}