using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombinationDetection : MonoBehaviour
{
    [System.Serializable]
    public struct Combination
    {
        public int[] CombinationCode;
        public UnityEvent OnTypedIn;
    }

    public UnityEvent CombinationFailed;
    public List<Combination> Combinations;

    private List<int> previouslyPressedButtons = new List<int>();
    private int maxCombination = 0;

    private void Start()
    {
        CalculateMaxCombination();
    }

    private void CalculateMaxCombination()
    {
        for (int i = 0; i < Combinations.Count; i++)
        {
            maxCombination = Mathf.Max(maxCombination, Combinations[i].CombinationCode.Length);
        }

    }

    public void EnterCombinationValue(int value)
    {
        previouslyPressedButtons.Add(value);

        //Cull front of array if overspaced
        if(previouslyPressedButtons.Count > maxCombination)
        {
            previouslyPressedButtons.RemoveAt(0);
        }
        Debug.Log(previouslyPressedButtons.Count);

        CheckCombinations();
    }

    public void VerifyCombination(Combination targetCombination)
    {
        if (previouslyPressedButtons.Count < targetCombination.CombinationCode.Length) return; // Not long enough

        for(int i = 0; i < targetCombination.CombinationCode.Length; i++) 
        {
            if(previouslyPressedButtons[(previouslyPressedButtons.Count - targetCombination.CombinationCode.Length) + i] == targetCombination.CombinationCode[i])
            {
                continue;
            }
            else
            {
                return;
            }
        }

        //Combination Passed
        targetCombination.OnTypedIn.Invoke();
        previouslyPressedButtons.Clear();
        return;
    }

    public void CheckCombinations()
    {
        for(int i = 0; i < Combinations.Count; i++)
        {
            VerifyCombination(Combinations[i]);
        }

        CombinationFailed.Invoke();
    }
}
