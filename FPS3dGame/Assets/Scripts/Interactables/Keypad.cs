using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject Key;
    [SerializeField]
    private GameObject Door;
    public bool RequireKey;
    private bool Open;
    protected override void Interact()
    {
        if(RequireKey == true)
        {
            if(Key.activeSelf)
            {
                Open = !Open;
                Door.GetComponent<Animator>().SetBool("IsOpen",Open);
            }
        }
        else
        {
            Open = !Open;
            Door.GetComponent<Animator>().SetBool("IsOpen",Open);
        }
    }
    
}