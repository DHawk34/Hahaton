using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject blur;

    [SerializeField]
    private GameObject menu;
    // Start is called before the first frame update
    private void OnEnable()
    {
        InputManager.Input.Player.Pause.performed += togglePause;
    }

    private void togglePause(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
            blur.SetActive(false);

            Time.timeScale = 1;
        }
        else
        {
            menu.SetActive(true);
            blur.SetActive(true);

            Time.timeScale = 0;
        }
    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
