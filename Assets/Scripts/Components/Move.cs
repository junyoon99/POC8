using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float Damping = 0.9f;

    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    void OnMove() 
    {
        Vector2 inputValue = InputManager.Instance.input.Ingame.MoveDirection.ReadValue<Vector2>().normalized;

        if (inputValue != Vector2.zero)
        {
            rb2d.linearVelocity = inputValue * speed;
        }
        else 
        {
            rb2d.linearVelocity *= Damping;
        }
    }
}
