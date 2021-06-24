using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingObject : MonoBehaviour
{
    public List<Vector3> WayPoints = new List<Vector3>();
    public Rigidbody Body;
    public bool StopWhenPathComplete = false;

    [Min(0)]
    public float DurationOfMove = 2;

    private int pointDir = 1;
    private int pointIndex = 0;
    private float pointLerpPosition = 0;

    private void Start()
    {
        if (Body != null) Body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (WayPoints.Count < 2) return; // Don't run code if cannot

        pointLerpPosition += Time.fixedDeltaTime;
        Body.MovePosition(Vector3.Lerp(WayPoints[pointIndex], WayPoints[(pointIndex + pointDir)],pointLerpPosition / DurationOfMove));

        CheckPathDone();
    }

    private void CheckPathDone()
    {
        //Check if we have arrived at the desired position
        if(pointLerpPosition >= DurationOfMove)
        {
            pointIndex += pointDir;
            if(pointIndex >= WayPoints.Count-1 || pointIndex <= 0)
            {
                //Change Point Dir
                pointDir = -pointDir;
                
                if(StopWhenPathComplete)
                {
                    enabled = false;
                }
            }
            pointLerpPosition = 0;

        }
    }
}
