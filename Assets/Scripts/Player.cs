using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary> Главный класс игрока. Хранит ссылки на многие скрипты и классы.</summary>
public class Player : MonoBehaviour
{
    public const string TAG = "Player";

    public Inventory Inventory { get; } = new Inventory();



    void OnEnable() => InputManager.Input.Player.Enable();
    void OnDisable() => InputManager.Input.Player.Disable();
}
