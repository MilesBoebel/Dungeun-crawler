using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour 
{
    

    public static Action shootInput;
    public static Action reloadInput;
    private InputManager inputManager;
       

    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        if (inputManager.onFoot.Shoot.triggered)
            shootInput?.Invoke();


        if (inputManager.onFoot.Reload.triggered)
            reloadInput?.Invoke();
            
    }
}
