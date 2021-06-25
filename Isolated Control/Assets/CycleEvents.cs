using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CycleEvents : MonoBehaviour
{
    public int CurrentEvent;
    public UnityEvent[] Events;

    public void RunAndCycleEvent()
    {
        if(Events != null && Events[CurrentEvent] != null)
        {
            Events[CurrentEvent].Invoke();
        }

        CurrentEvent++;
        if(CurrentEvent >= Events.Length)
        {
            CurrentEvent = 0;
        }
    }
}
