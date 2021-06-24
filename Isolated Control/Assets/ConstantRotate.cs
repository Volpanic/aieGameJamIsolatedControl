using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotate : MonoBehaviour
{
    public Quaternion RotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.localRotation *= Quaternion.Euler(RotateSpeed.eulerAngles * Time.deltaTime);
    }
}
