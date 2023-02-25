using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateKeypad : Interactable
{
    [SerializeField]
    private GameObject WeaponCrate;
    private bool isOpen;
    protected override void Interact()
    {
        isOpen = !isOpen;
        WeaponCrate.GetComponent<Animator>().SetBool("isOpen", isOpen);
    }
}