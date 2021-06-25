using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerInvoke : MonoBehaviour
{
    public UnityEvent OnTriggerEntered;
    public bool OnlyOnce = true;

    public string TagMask = "";

    private void OnTriggerEnter(Collider other)
    {
        if (TagMask == "" || TagMask == other.tag)
        {
            OnTriggerEntered.Invoke();
            if (OnlyOnce) enabled = false;
        }
    }
}
