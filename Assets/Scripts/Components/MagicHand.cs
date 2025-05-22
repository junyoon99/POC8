using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagicHand : MonoBehaviour
{
    public List<MagicSkill> LeftHand = new();
    public int LeftcurrentIndex = 0;
    public float LeftHandDelay = 0.1f;
    public float LeftHandCoolTime = 1f;
    float LeftHandCoolTimer = 0f;
    public float Accuracy = 1f;
    public int FireObjectNumber = 1;

    public List<MagicSkill> RightHand = new();
    public int RightcurrentIndex = 0;
    public float RightHandDelay = 0.1f;
    public float RightHandCoolTime = 1f;
    //float RightHandCoolTimer = 0f;

    public GameObject SelectBox;

    void Start()
    {
    }

    private void Update()
    {
        LeftHand.Clear();
        foreach(Transform transform in UIManager.Instance.LeftHand) 
        {
            MagicSkill skill = transform.GetComponentInChildren<MagicSkill>();
            if (skill) 
            {
                LeftHand.Add(skill);
            }
        }

        if (LeftHandCoolTimer > 0) 
        {
            LeftHandCoolTimer -= Time.deltaTime;
        }
        else 
        {
            LeftHandCoolTimer = 0;
        }
        UIManager.Instance.leftHandCoolTime.CoolTimeUpdate(LeftHandCoolTimer);

        if (InputManager.Instance.input.Ingame.LeftHandFire.IsPressed()) 
        {
            LeftHand_FireMagic();
        }
    }

    void LeftHand_FireMagic()
    {
        if (LeftHand.Count == 0) 
        {
            Debug.Log("왼손에 스킬없음");
            return;
        }
        if (LeftHandCoolTimer > 0) 
        {
            return;
        }
        StartCoroutine(Fire(LeftHand, LeftHandDelay));
        LeftHandCoolTimer = LeftHandCoolTime;
    }

    IEnumerator Fire(List<MagicSkill> skillList, float delay)
    {
        while (LeftcurrentIndex < LeftHand.Count)
        {
            for (int i = FireObjectNumber; i > 0; i--) 
            {
                LeftHand[LeftcurrentIndex].Fire(transform.position, ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized + new Vector3( Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy), 0)).normalized, i);
            }

            LeftcurrentIndex++;
            yield return new WaitForSeconds(delay);
        }
        LeftcurrentIndex = 0;
    }
}
