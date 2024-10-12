using UnityEngine;

public class ToggleActiveScript : MonoBehaviour
{
    public void ToggleActive()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}
