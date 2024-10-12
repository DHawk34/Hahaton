using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class TestLoadToInventory : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> itemsToAdd;

    private Player player;

    void Awake()
    {
        player = GameObject.FindWithTag(Player.TAG).GetComponent<Player>();

        InputManager.ToggleActionMap(InputManager.Input.Player);
        InputManager.Input.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(InputAction.CallbackContext ctx)
    {
        if (itemsToAdd.Count == 0)
            return;

        var item = itemsToAdd[0];
        itemsToAdd.RemoveAt(0);

        player.Inventory.TryAddItem(item);
    }
}
