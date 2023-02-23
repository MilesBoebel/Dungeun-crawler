using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject Door;
    private bool Open;
    protected override void Interact()
    {
        Open = !Open;
        Door.GetComponent<Animator>().SetBool("IsOpen",Open);
    }
}