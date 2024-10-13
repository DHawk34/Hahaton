using UnityEngine;
using UnityEngine.EventSystems;

public class Item3dViewer : MonoBehaviour, IDragHandler
{
    [SerializeField] private GameObject pdaButtons;
    private Player player;
    private GameObject wrapper;
    private GameObject obj;

    void Awake()
    {
        player = GameObject.FindWithTag(Player.TAG).GetComponent<Player>();
        player.Inventory.ShouldOpenItem3dViewer += Open;

        wrapper = transform.GetChild(0).gameObject;
    }



    private void Open(InventoryItem item)
    {
        if (obj != null)
            Destroy(obj);

        obj = Instantiate(item.Model3D, new Vector3(100, 100, 100), item.Quanternion);
        this.wrapper.SetActive(true);

        pdaButtons.SetActive(item.ItemName == "Pda");
    }

    public void Close()
    {
        if (obj != null)
            Destroy(obj);
        this.wrapper.SetActive(false);

        pdaButtons.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        obj.transform.eulerAngles += new Vector3(0, -eventData.delta.x);
    }
}
