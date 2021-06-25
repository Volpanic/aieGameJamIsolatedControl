using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Fade FadeManager;
    public int TargetBuildIndex;

    private bool active = false;

    void Update()
    {
        if (active)
        {
            if (FadeManager.FadeDone)
            {
                SceneManager.LoadScene(TargetBuildIndex);
            }
        }
    }

    public void StartTransition()
    {
        FadeManager.FadeOut();
        active = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
