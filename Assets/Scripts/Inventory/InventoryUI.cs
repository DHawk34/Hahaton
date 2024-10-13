using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject[] itemBackgrounds;
    [SerializeField] private Image[] itemIcons;

    private Inventory playerInventory;



    void Awake()
    {
        playerInventory = GameObject.FindWithTag(Player.TAG).GetComponent<Player>().Inventory;
        playerInventory.ItemAdded += PlayerInventory_ItemAdded;
        playerInventory.ItemRemoved += PlayerInventory_ItemRemoved;
    }

    private void PlayerInventory_ItemAdded(int index, InventoryItem item)
    {
        var icon = itemIcons[index];
        icon.sprite = item.Sprite;
        ShowItemIcon(icon, true);
    }

    private void PlayerInventory_ItemRemoved(int index)
    {
        var icon = itemIcons[index];
        icon.sprite = null;
        ShowItemIcon(icon, false);
    }



    public void SetActiveItemIndex(int index)
    {
        // clamp max
        if (index >= itemBackgrounds.Length)
            index = itemBackgrounds.Length - 1;

        bool shouldBeEnabled = playerInventory.ActiveItemIndex != index || (index >= 0 && !itemBackgrounds[index].activeSelf);
        playerInventory.ActiveItemIndex = index;

        foreach (var item in itemBackgrounds)
        {
            item.SetActive(false);
        }

        if (playerInventory.ItemsCount > index && shouldBeEnabled && index >= 0)
        {
            itemBackgrounds[index].SetActive(true);
        }
    }

    public void Open3dView(int itemIndex)
    {
        playerInventory.InvokeShouldOpenItem3dViewer(itemIndex);
    }

    private void ShowItemIcon(Image icon, bool state)
    {
        var color = icon.color;
        color.a = state ? 1 : 0;

        icon.color = color;
    }
}
