using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryRoot : MonoBehaviour
{
    void Start()
    {
        InputManager.Instance.input.Ingame.Inventory.started += ShowInventory;
    }

    void ShowInventory(InputAction.CallbackContext ctx)
    {
        GetComponent<Canvas>().enabled = GetComponent<Canvas>().enabled ? false : true;
    }
}
