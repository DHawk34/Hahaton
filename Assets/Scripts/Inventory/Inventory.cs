using System;
using System.Collections.Generic;

public class Inventory
{
    public const int MAX_ITEMS = 3;
    public int ItemsCount => items.Count;
    public int ActiveItemIndex { get; set; } = -1;

    public event Action<int, InventoryItem> ItemAdded;
    public event Action<int> ItemRemoved;
    public event Action<InventoryItem> ShouldOpenItem3dViewer;

    private readonly List<InventoryItem> items = new(MAX_ITEMS);



    public bool TryAddItem(InventoryItem item)
    {
        if (items.Count >= MAX_ITEMS)
            return false;

        items.Add(item);
        ActiveItemIndex = items.Count - 1;
        ItemAdded?.Invoke(items.Count - 1, item);

        return true;
    }

    public bool TryRemoveItem(InventoryItem item)
    {
        bool success = items.Remove(item);

        if (success)
        {
            ActiveItemIndex = -1;
            ItemRemoved?.Invoke(items.Count);
        }

        return success;
    }

    public bool TryGetActiveItem(out InventoryItem item)
    {
        if (ActiveItemIndex < 0)
        {
            item = null;
            return false;
        }

        item = items[ActiveItemIndex];
        return true;
    }

    public void InvokeShouldOpenItem3dViewer(int itemIndex)
    {
        if (items.Count > itemIndex)
            ShouldOpenItem3dViewer?.Invoke(items[itemIndex]);
    }
}
