using UnityEngine;

public abstract class Magic : MonoBehaviour
{
    public abstract float Damage { get; set; }
    public abstract float Range { get; set; }
    public abstract float Speed { get; set; }

    public abstract Vector2 Direction { get; set; }
}
