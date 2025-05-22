using System.Collections.Generic;
using UnityEngine;

public class LeftHandCanvas : MonoBehaviour
{
    void Start()
    {
        UIManager.Instance.LeftHand = transform;
    }

    void Update()
    {
        HandUpdate();
    }

    void HandUpdate() 
    {
    }
}
