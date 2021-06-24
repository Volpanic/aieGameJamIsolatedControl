using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent OnInteract;
    public GameEvent InteractEvent;
    public void InteractedWith()
    {
        if (enabled)
        {
            OnInteract.Invoke();
            if(InteractEvent != null) InteractEvent.Raise();
        }
    }
}
