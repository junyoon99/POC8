using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType(typeof(UIManager)) as UIManager;
                if (Instance == null)
                {
                    Debug.LogError("UIManager¾øÀ½!");
                }
            }
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    public Transform LeftHand;
    public Transform RightHand;
    public LeftHandCoolTime leftHandCoolTime;
}
