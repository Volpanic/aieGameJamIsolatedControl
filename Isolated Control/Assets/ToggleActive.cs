using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    public void ToggleSelfActive()
    {
        if (gameObject.activeInHierarchy) gameObject.SetActive(false);
        else gameObject.SetActive(true);
    }
}
