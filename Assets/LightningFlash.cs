using UnityEngine;

public class LightningFlash : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; 
    public float flashDuration = 0.2f;     
    public float flashInterval = 3f;       

    private float timer = 0f;

    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= flashInterval)
        {
            StartCoroutine(Flash());
            timer = 0f;
        }
    }

    System.Collections.IEnumerator Flash()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f); 
        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
    }
}
