using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void LoadNewLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene(0);
    }
}
