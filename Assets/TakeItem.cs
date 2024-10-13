using System;
using System.Linq;

using UnityEngine;
using UnityEngine.Events;

public class TakeItem : MonoBehaviour
{
    public UnityEvent action;

    private Inventory playerInventory;

    private BoxCollider2D boxCollider2D;

    [SerializeField]
    private InventoryItem item;

    void Awake()
    {
        playerInventory = GameObject.FindWithTag(Player.TAG).GetComponent<Player>().Inventory;
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }


    void OnMouseDown()
    {
        if (!playerInventory.TryAddItem(item))
            return;

        action?.Invoke();
        
        boxCollider2D.enabled = false;
    }

}
