using UnityEngine;

public abstract class MagicSkill : MonoBehaviour
{
    public abstract string Name { get; }
    public abstract float Cooldown { get; }
    public abstract float CoolTimer { get; }
    public abstract GameObject Magic { get; }

    public abstract bool Fire(Vector2 position, Vector2 direction, int count);
}
