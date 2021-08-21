using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas = null;

    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0; //stop game time
        Cursor.lockState = CursorLockMode.None; // unlock cursor
        Cursor.visible = true; // make cursor visible
    }
}
