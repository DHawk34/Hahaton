using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScaler : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer roomBackground;

    private void Awake()
    {
        mainCamera = Camera.main;
        roomBackground = GetComponent<SpriteRenderer>();

        ResizeRoom();
    }

    public void ResizeRoom()
    {
        //spriteRenderer.sprite.texture.filterMode = FilterMode.Point;

        double width = roomBackground.sprite.bounds.size.x;
        double worldScreenHeight = Camera.main.orthographicSize * 2.0;
        double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;


        // Resize
        roomBackground.transform.localScale = new Vector2(1, 1) * (float)(worldScreenWidth / width);
    }
}
