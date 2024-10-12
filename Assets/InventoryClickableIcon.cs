using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryClickableIcon : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int itemIndex;
    [SerializeField] private InventoryUI inventoryUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 1)
        {
            inventoryUI.SetActiveItemIndex(itemIndex);
        }
        else if (eventData.clickCount == 2)
        {
            inventoryUI.SetActiveItemIndex(-1);
            inventoryUI.Open3dView(itemIndex);
        }
    }
}
