using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 15f;

    [System.Obsolete]
    void Update()
{
    float currentSpeed = FindObjectOfType<GameManager>().pipeSpeed;

    currentSpeed = Mathf.Min(currentSpeed, 200f);

    transform.position += Vector3.left * currentSpeed * Time.deltaTime;

    if (transform.position.x < -30f)
    {
        Destroy(gameObject);
    }
}


}
