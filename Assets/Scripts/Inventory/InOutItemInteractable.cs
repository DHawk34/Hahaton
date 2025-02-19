using System;
using System.Linq;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Interactions;

public class InOutItemInteractable : MonoBehaviour
{
    [SerializeField] private string[] allowedItemName;
    public UnityEvent action;
    public UnityEvent<int> actionInt;

    public UnityEvent<int> actionRemoveInt;


    private Inventory playerInventory;

    public InventoryItem item;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite sprite;

    public bool slotTaken;

    void Awake()
    {
        playerInventory = GameObject.FindWithTag(Player.TAG).GetComponent<Player>().Inventory;
    }


    void OnMouseDown()
    {
        if (item == null)
        {
            if (!playerInventory.TryGetActiveItem(out var item))
                return;

            Debug.Log(item.ItemName);

            if (!allowedItemName.Contains(item.ItemName))
                return;

            if (!playerInventory.TryRemoveItem(item))
                return;

            this.item = item;

            ChangeSprite();

            actionInt?.Invoke(item.ItemName[5] - '0');

        }
        else
        {
            if (!playerInventory.TryAddItem(item))
                return;


            actionRemoveInt?.Invoke(item.ItemName[5] - '0');

            item = null;

            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        if (!slotTaken)
        {
            spriteRenderer.sprite = sprite;
            slotTaken = true;
        }
        else
        {
            spriteRenderer.sprite = null;
            slotTaken = false;
        }
    }
}
