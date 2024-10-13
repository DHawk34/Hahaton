using UnityEngine;

public class AddItemsOnStart : MonoBehaviour
{
    [SerializeField] private InventoryItem[] itemsToAdd;

    void Start()
    {
        var playerInventory = GameObject.FindWithTag(Player.TAG).GetComponent<Player>().Inventory;

        foreach (var item in itemsToAdd)
        {
            playerInventory.TryAddItem(item);
        }
    }
}
