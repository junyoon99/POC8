using UnityEngine;

public class Skill_MagicBullet : MagicSkill
{
    public string skillName;
    public float cooldown = 1f;
    public GameObject magicPrefab;
    float timer = 0f;

    public override string Name 
    { 
        get => skillName; 
    }
    public override float Cooldown 
    {
        get => cooldown;
    }
    public override float CoolTimer
    {
        get => timer;
    }
    public override GameObject Magic 
    {
        get => magicPrefab;
    }

    public void Awake()
    {
        magicPrefab = Resources.Load<GameObject>("Magic/MagicBullet");
        if (magicPrefab == null)
        {
            Debug.LogError("마법탄 프리팹 찾을 수 없음");
        }
    }

    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public override bool Fire(Vector2 position, Vector2 direction, int count)
    {
        if (CoolTimer > 0) 
        {
            return false;
        } 

        GameObject spawnedObj = Instantiate(magicPrefab, position, Quaternion.identity);
        spawnedObj.GetComponent<Magic>().Direction = direction;

        if (count == 1) 
        {
            timer = cooldown;
        }

        return true;
    }
}
