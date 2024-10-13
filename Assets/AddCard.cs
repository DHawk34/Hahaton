using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddCard : MonoBehaviour
{
    [SerializeField] private string allowedItemName;
    public UnityEvent action;



    private Inventory playerInventory;

    private InventoryItem item;

    void Awake()
    {
        playerInventory = GameObject.FindWithTag(Player.TAG).GetComponent<Player>().Inventory;
    }


    void OnMouseDown()
    {
        if (!playerInventory.TryGetActiveItem(out var item))
            return;


        if (!allowedItemName.Contains(item.ItemName))
            return;

        if (!playerInventory.TryRemoveItem(item))
            return;

        this.item = item;

        // ChangeSprite();

        action?.Invoke();

    }

    // private void ChangeSprite()
    // {
    //     if (!slotTaken)
    //     {
    //         spriteRenderer.sprite = sprite;
    //         slotTaken = true;
    //     }
    //     else
    //     {
    //         spriteRenderer.sprite = null;
    //         slotTaken = false;
    //     }
    // }
}
