using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private InputManager inputManager;
    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadKey;

    private void Update()
    {
        if (inputManager.onFoot.Shoot.triggered)
        {
            shootInput?.Invoke();
        }

         if (inputManager.onFoot.Reload.triggered)
        {
            reloadInput?.Invoke();
        }
    }
    void Start()
    {
    inputManager = GetComponent<InputManager>();
    }
}
