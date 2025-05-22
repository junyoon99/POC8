using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType(typeof(InputManager)) as InputManager;
                if (Instance == null)
                {
                    Debug.LogError("��ǲ�Ŵ�������!");
                }
            }
            return _instance;
        }
    }

    public PlayerInputActions input;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        input = new PlayerInputActions();
        input.Enable();
    }
}
