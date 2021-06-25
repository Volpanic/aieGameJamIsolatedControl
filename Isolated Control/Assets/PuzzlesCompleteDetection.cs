using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzlesCompleteDetection : MonoBehaviour
{
    [Min(1)]
    public int PuzzleAmount = 3;
    public UnityEvent OnComplete;

    private int completeAmount = 0;

    public void AddComplete()
    {
        completeAmount++;

        if(completeAmount >= PuzzleAmount)
        {
            OnComplete.Invoke();
            enabled = false;
        }
    }
}
