using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Fade FadeController;

    private CharacterController controller;
    private bool Respawning = false;
    private Vector3 targetPoint;
    private Quaternion targetRot;

    // Start is called before the first frame update
    void Start()
    {
        //Create empty object to keep track of respawn point
        targetPoint = transform.position;
        targetRot = transform.rotation;

        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(Respawning)
        {
            if(FadeController.FadeDone)
            {
                if (controller != null) controller.enabled = false;
                transform.position = targetPoint;
                transform.rotation = targetRot;
                if (controller != null) controller.enabled = true;
                FadeController.FadeIn();
            }
        }
    }

    public void UpdateRespawnPoint(Transform toCopy)
    {
        targetPoint = toCopy.position;
        targetRot = toCopy.rotation;
    }

    public void Respawn()
    {
        if (Respawning) return;

        if(FadeController == null)
        {
            if (controller != null) controller.enabled = false;
            transform.position = targetPoint;
            transform.rotation = targetRot;
            if (controller != null) controller.enabled = true;
        }
        else
        {
            Respawning = true;
            FadeController.FadeOut();
        }
    }
}
