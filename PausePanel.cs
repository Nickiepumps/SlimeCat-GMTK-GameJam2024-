using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject PlayPanel;
    public bool isPlay;
    private void Start()
    {
        Pause();
    }
    public void OnPlayButtonPressed()
    {
        if (isPlay)
        {
            Pause();
        }
        else
        {
            Continue();
        }
    }
    public void Pause()
    {
        PlayPanel.SetActive(true);
        Time.timeScale = 0;
        isPlay = false;
    }
    public void Continue()
    {
        PlayPanel.SetActive(false);
        Time.timeScale = 1;
        isPlay = true;
    }
}
