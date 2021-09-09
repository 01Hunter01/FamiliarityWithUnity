using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    public UnityEvent active;
    public UnityEvent unactive;

    private bool _isPaused;

    private void Awake()
    {
        _isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
            {
                Time.timeScale = 0;
                _isPaused = true;
                active.Invoke();
            }
            else
            {
                Time.timeScale = 1;
                _isPaused = false;
                unactive.Invoke();
            }
        }
    }

    public void Resume()
    {
        _isPaused = false;
        Time.timeScale = 1;
        unactive.Invoke();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        _isPaused = false;
        Time.timeScale = 1;
    }
    
    public void Settings()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    
}

