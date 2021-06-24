using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionChecker : MonoBehaviour
{
    Camera cam;

    [Tooltip("The distance of the raycast.")]
    public float ArmReach = 5;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Cast ray from center of screen
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, ArmReach))
            {
                hit.collider.gameObject.BroadcastMessage("InteractedWith",SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
