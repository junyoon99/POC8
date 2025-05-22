using UnityEngine;

public class Bomb : Magic
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 99f;
    [SerializeField] float speed = 2f;
    [SerializeField] Vector2 direction = new Vector2(1, 0); // Default direction to the right
    public override float Damage
    {
        get => damage;
        set => damage = value;
    }
    public override float Range
    {
        get => range;
        set => range = value;
    }
    public override float Speed
    {
        get => speed;
        set => speed = value;
    }
    public override Vector2 Direction
    {
        get => direction;
        set => direction = value;
    }

    Rigidbody2D rb2d;
    Vector2 startPosition;
    public float BoomTimer;
    public GameObject BoomEffect;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        BoomEffect = Resources.Load<GameObject>("Magic/BombBoomEffect");
    }
    private void Start()
    {
        startPosition = transform.position;
        rb2d.AddForce(direction.normalized * speed, ForceMode2D.Impulse);
        rb2d.AddTorque(Random.Range(-1f, 1f), ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, startPosition) > range)
        {
            Destroy(gameObject);
        }

        if (BoomTimer < 0)
        {
            Instantiate(BoomEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else 
        {
            BoomTimer -= Time.deltaTime;
        }
    }
}
