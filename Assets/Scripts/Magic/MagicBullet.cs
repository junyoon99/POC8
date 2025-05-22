using UnityEngine;

public class MagicBullet : Magic
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 5f;
    [SerializeField] float speed = 20f;
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
    public override Vector2 Direction { 
        get => direction;
        set => direction = value;
    }

    Rigidbody2D rb2d;
    Vector2 startPosition;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }
    private void Start()
    {
        startPosition = transform.position;
        rb2d.linearVelocity = direction.normalized * speed;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, startPosition) > range)
        {
            Destroy(gameObject);
        }
    }
}
