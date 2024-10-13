using System;
using System.Collections.Generic;
using System.ComponentModel;

using UnityEngine;
using UnityEngine.InputSystem;

public static class InputManager
{
    public static PlayerControls Input { get; } = new PlayerControls();
    public static event Action<InputActionMap> OnActionMapChanged;

    static InputManager()
    {
        Input.Debug.Enable();
    }



    /// <summary>
    /// Включает нужную мапу, отключая остальные (кроме <paramref name="Debug"/>). В аргументы посылаем <see cref="InputManager.Input"/>.НужнаяМапа.
    /// </summary>
    public static void ToggleActionMap(InputActionMap actionMap)
    {
        if (actionMap.enabled)
            return;

        Input.Disable(); // Отключить все мапы
        actionMap.Enable();
        Input.Debug.Enable();

        OnActionMapChanged?.Invoke(actionMap);
    }

    /// <summary>
    /// Отключает все мапы, кроме <paramref name="Debug"/>.
    /// </summary>
    public static void DisableAllActionMapsExceptDebug()
    {
        Input.Disable();
        Input.Debug.Enable();
    }
}
