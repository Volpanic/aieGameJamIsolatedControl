using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialougeLine // Stores data for each dialouge line
{
    [TextArea(4,10)]
    public string DialougeText;
}

[CreateAssetMenu(fileName = "NewDialouge",menuName ="Dialouge",order = 0)]
public class DialougeSequence : ScriptableObject
{
    public List<DialougeLine> DialougeLines;
}