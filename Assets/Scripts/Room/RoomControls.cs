using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomControls : MonoBehaviour
{
    private Button leftButton;
    private Button rightButton;
    private Button upButton;
    private Button downButton;

    private Camera mainCamera;

    [SerializeField]
    private Transform dialog;

    [SerializeField]
    private Transform inventory;

    [SerializeField]
    private FadeInOut fadeInOut;

    [SerializeField]
    private Transform leftRoom;

    [SerializeField]
    private Transform rightRoom;

    [SerializeField]
    private Transform upRoom;

    [SerializeField]
    private Transform downRoom;

    private void Awake()
    {
        mainCamera = Camera.main;
        leftButton = this.transform.Find("LeftButton").GetComponent<Button>();
        rightButton = this.transform.Find("RightButton").GetComponent<Button>();
        upButton = this.transform.Find("UpButton").GetComponent<Button>();
        downButton = this.transform.Find("DownButton").GetComponent<Button>();

        rightButton.onClick.AddListener(startGoToRight);
        leftButton.onClick.AddListener(startGoToLeft);
        // upButton.onClick.AddListener(startGoToUp);
        // downButton.onClick.AddListener(startGoToDown);
    }
    void startGoToRight()
    {
        fadeInOut.FadeIn();
        fadeInOut.FadeInEnded = null;
        fadeInOut.FadeInEnded += goToRight;
    }
    void goToRight()
    {
        fadeInOut.FadeInEnded -= goToRight;
        goToRoom(rightRoom);
        fadeInOut.FadeOut();
    }
    void startGoToLeft()
    {
        fadeInOut.FadeIn();
        fadeInOut.FadeInEnded = null;
        fadeInOut.FadeInEnded += goToLeft;
    }
    void goToLeft()
    {
        fadeInOut.FadeInEnded -= goToLeft;
        goToRoom(leftRoom);
        fadeInOut.FadeOut();
    }

    public void goToRoom(Transform roomTransform)
    {
        if (roomTransform)
        {
            mainCamera.transform.position = (Vector2)roomTransform.position;
            dialog.position = new Vector3(roomTransform.position.x, roomTransform.position.y, 1f);
            inventory.position = new Vector3(roomTransform.position.x, roomTransform.position.y, 1f);
        }
    }
}
