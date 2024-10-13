using UnityEngine;
using UnityEngine.EventSystems;

public class Item3dViewer : MonoBehaviour, IDragHandler
{
    private Player player;
    private GameObject obj;

    void Awake()
    {
        player = GameObject.FindWithTag(Player.TAG).GetComponent<Player>();
        player.Inventory.ShouldOpenItem3dViewer += OpenItem3dViewer;
    }



    private void OpenItem3dViewer(InventoryItem item)
    {
        if (obj != null)
            Destroy(obj);

        obj = Instantiate(item.Model3D, new Vector3(100, 100, 100), Quaternion.identity);
    }

    public void OnDrag(PointerEventData eventData)
    {
        obj.transform.eulerAngles += new Vector3(0, -eventData.delta.x);
    }
}
