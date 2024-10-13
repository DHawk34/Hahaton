using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class InteractableGetItemFromInventory : MonoBehaviour
{
    [SerializeField] private string[] allowedItemName;
    [SerializeField] private UnityEvent action;
    [SerializeField] private UnityEvent<int> actionInt;

    private Inventory playerInventory;

    void Awake()
    {
        playerInventory = GameObject.FindWithTag(Player.TAG).GetComponent<Player>().Inventory;
    }



    void OnMouseDown()
    {
        if (!playerInventory.TryGetActiveItem(out var item))
            return;

        if (!allowedItemName.Contains(item.name))
            return;

        actionInt?.Invoke((int)item.name[0]);
    }
}
