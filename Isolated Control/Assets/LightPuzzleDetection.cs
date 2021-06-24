using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightPuzzleDetection : MonoBehaviour
{
    public UnityEvent OnPuzzleComplete;
    public List<GameObject> ObjectsToCheckActive;

    public void VertifyPuzzle()
    {
        for(int i = 0; i < ObjectsToCheckActive.Count; i++)
        {
            if (ObjectsToCheckActive[i] == null || !ObjectsToCheckActive[i].activeInHierarchy)
                return;
        }

        OnPuzzleComplete.Invoke();
        enabled = false;
    }
}
