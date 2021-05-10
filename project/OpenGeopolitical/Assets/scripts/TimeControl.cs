using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public Button pauseButton;
    [SerializeField]
    private Sprite[] pauseSprites;
    public int isPaused { get; set; }

    private void togglePauseSprite()
    {
        pauseButton.image.sprite = pauseSprites[isPaused];
    }
    public void Pause()
    {
        if (isPaused == 1)
        {
            isPaused = 0;
            togglePauseSprite();
        } else
        {
            isPaused = 1;
            togglePauseSprite();
        }
    }
}
