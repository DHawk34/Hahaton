using System;
using System.Linq;

using UnityEngine;
using UnityEngine.Events;

public class Nails : MonoBehaviour
{
    [SerializeField] private string[] allowedItemName;
    public UnityEvent action;
    public UnityEvent<int> actionInt;

    private Inventory playerInventory;

    private InventoryItem item;
    private SpriteRenderer spriteRenderer;

    [SerializeField] FusePlate plate;

    void Awake()
    {
        playerInventory = GameObject.FindWithTag(Player.TAG).GetComponent<Player>().Inventory;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    void OnMouseDown()
    {
        if (!playerInventory.TryGetActiveItem(out var item))
            return;

      
        if (!allowedItemName.Contains(item.ItemName))
            return;

        AudioManager.Instance.PlaySFX("ScrewDriver");

        plate.MinusNail();

        this.gameObject.SetActive(false);

    }
}
