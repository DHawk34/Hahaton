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
        icon.gameObject.SetActive(true);
    }

    private void PlayerInventory_ItemRemoved(int index)
    {
        var icon = itemIcons[index];
        icon.sprite = null;
        icon.gameObject.SetActive(false);
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
}
