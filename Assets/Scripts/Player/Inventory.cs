using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Inventory
{
    public const int MAX_ITEMS = 3;
    public int ActiveItemIndex { get; set; } = -1;
    public int ItemsCount => items.Count;

    public event Action<int, InventoryItem> ItemAdded;
    public event Action<int> ItemRemoved;
    public event Action<InventoryItem> ShouldOpenItem3dViewer;

    private readonly List<InventoryItem> items = new(MAX_ITEMS);



    public bool TryAddItem(InventoryItem item)
    {
        if (items.Count >= MAX_ITEMS)
            return false;

        items.Add(item);
        ItemAdded?.Invoke(items.Count - 1, item);

        return true;
    }

    public bool TryRemoveItem(InventoryItem item)
    {
        bool success = items.Remove(item);

        if (success)
            ItemRemoved?.Invoke(items.Count);

        return success;
    }

    public void InvokeShouldOpenItem3dViewer(int itemIndex)
    {
        if (items.Count > itemIndex)
            ShouldOpenItem3dViewer?.Invoke(items[itemIndex]);
    }
}
