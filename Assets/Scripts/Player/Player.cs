using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

/// <summary> Главный класс игрока. Хранит ссылки на многие скрипты и классы.</summary>
public class Player : MonoBehaviour
{
	public PlayerMovement Movement { get; private set; }
	//public PlayerStats Stats { get; private set; }
	//public PlayerHealth PlayerHealth { get; private set; }
	//public PlayerInteractable PlayerInteractable { get; private set; }
	//public Inventory Inventory { get; private set; }

	//public StateManager StateManager { get; } = new StateManager();

    public SpriteRenderer SpriteRenderer { get; private set; }

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
		Movement = GetComponent<PlayerMovement>();
		SpriteRenderer = GetComponent<SpriteRenderer>();
		//PlayerHealth = GetComponent<PlayerHealth>();
		//PlayerInteractable = GetComponent<PlayerInteractable>();

		// 
		//Stats = new PlayerStats();
		//Inventory = new Inventory(this);
	}



	void OnEnable()
	{
		input.Player.Enable();
	}
	void OnDisable()
	{
		input.Player.Disable();
	}

	private void PlayerInput_onControlsChanged(PlayerInput obj)
	{
		IsUsingGamepad = obj.currentControlScheme == input.GamepadScheme.name;
		
		// TODO: Хз насчет .Reset()
		input.Player.AbilityCrosshair.Reset();

		Debug.LogWarning($"Controlls changed {obj.currentControlScheme}!");
	}
}
