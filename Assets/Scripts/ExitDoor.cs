using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] string levelPassword;
    [SerializeField] TextMeshProUGUI passwordText;
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] GameObject endLevelScreen;
    AudioManager audioManager;


    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ResetLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (levelPassword.ToUpper()==passwordText.text.ToUpper())
        {
            endLevelScreen.SetActive( true);
            audioManager.PlayDoorSound();
            passwordText.text = "";
            messageText.text = "";
            
        }
        else
        {
            
            messageText.enabled = true;
            Invoke(nameof(DisableMessageText), 2);
        }

    }

    void DisableMessageText() 
    {
        messageText.enabled = false;
    }

    public void LoadNextLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene(0);
        
    }

    public void ResetLevel()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
