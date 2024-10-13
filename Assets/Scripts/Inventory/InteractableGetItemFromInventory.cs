using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class InteractableGetItemFromInventory : MonoBehaviour
{
    [SerializeField] private string[] allowedItemName;
    public UnityEvent action;
    public UnityEvent<int> actionInt;

    private Inventory playerInventory;

    private InventoryItem item;
    [SerializeField] private SpriteRenderer spriteRenderer;

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

            changeSprite();

            actionInt?.Invoke(item.ItemName[5] - '0');

        }
        else
        {
            if (!playerInventory.TryAddItem(item))
                return;

            item = null;

            changeSprite();

        }
    }

    void changeSprite()
    {
        spriteRenderer.sprite = item.Sprite;
    }
}
