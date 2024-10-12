using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Inventory
{
    public int MaxItems { get; }

    private readonly List<InventoryItem> items = new(5);

    public Inventory(int capacity)
    {
        this.MaxItems = capacity;
        this.items = new(capacity);
    }



    public bool TryAddItem(InventoryItem item)
    {
        if (items.Count >= MaxItems)
            return false;

        items.Add(item);
        return true;
    }

    public bool TryRemoveItem(InventoryItem item)
    {
        return items.Remove(item);
    }
}
