using UnityEngine;

public class BombBoomEffect : MonoBehaviour
{
    Vector2 effectScale;
    public float BoomTime = 0.5f;
    float elapsedTime = 0f;
    private void OnEnable()
    {
        effectScale = transform.localScale;
        transform.localScale = Vector2.zero;
    }
    void Update()
    {
        if (elapsedTime < BoomTime)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, effectScale, elapsedTime / BoomTime);
            Color color = GetComponent<SpriteRenderer>().color;
            color.a = Mathf.Lerp(1, 0, elapsedTime / BoomTime);
            GetComponent<SpriteRenderer>().color = color;
        }
        else 
        {
            Destroy(gameObject);
        }
        elapsedTime += Time.deltaTime;
    }
}
