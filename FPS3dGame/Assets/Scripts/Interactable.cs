using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Add or remvoe InteractioEvent component to this gameObject
    public bool useEvents;
    //Message displayed to player when looking at an interatable
    public string promptMessage;

    //This function will be called from our player
    public void BaseInteract()
    {
        if(useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }

    protected virtual void Interact()
    {
        //No code needed 
        //It will be overidden by our subclass
    }
}
