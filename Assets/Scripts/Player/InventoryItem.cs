using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Collectable Item")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite sprite;

    public string ItemName => itemName;
}
