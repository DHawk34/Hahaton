using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Collectable Item")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite sprite;
    [SerializeField] private GameObject model3D;

    public string ItemName => itemName;
    public Sprite Sprite => sprite;
    public GameObject Model3D => model3D;
}
