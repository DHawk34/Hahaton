using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

/// <summary> Главный класс игрока. Хранит ссылки на многие скрипты и классы.</summary>
public class Player : MonoBehaviour
{
    [SerializeField] private int inventoryMaxItems = 5;

    public Inventory Inventory { get; private set; }

    //public StateManager StateManager { get; } = new StateManager();

    public bool IsUsingGamepad { get; private set; }



    // Input
    private PlayerControls input;
    private PlayerInput playerInput;



    // ==================================================
    // Awake
    // ==================================================
    void Awake()
    {
        // Input system
        input = InputManager.Input;
        playerInput = GetComponent<PlayerInput>();
        playerInput.onControlsChanged += PlayerInput_onControlsChanged;

        // Components

        // 
        Inventory = new Inventory(inventoryMaxItems);
    }



    void OnEnable() => input.Player.Enable();
    void OnDisable() => input.Player.Disable();

    private void PlayerInput_onControlsChanged(PlayerInput obj)
    {
        IsUsingGamepad = obj.currentControlScheme == input.GamepadScheme.name;

        // TODO: хз насчет .Reset()
        input.Player.AbilityCrosshair.Reset();

        Debug.LogWarning($"Controlls changed {obj.currentControlScheme}!");
    }
}
