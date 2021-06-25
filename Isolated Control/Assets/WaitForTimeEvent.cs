using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitForTimeEvent : MonoBehaviour
{
    public float MaxTime = 10f;
    public UnityEvent AfterTime;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= MaxTime)
        {
            AfterTime.Invoke();
            enabled = false;
        }
    }
}
