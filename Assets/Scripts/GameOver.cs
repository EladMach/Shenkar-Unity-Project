using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    
    
    void Start()
    {
        StartCoroutine(GameOverRoutine());
    }

    
    void Update()
    {
        
    }

    IEnumerator GameOverRoutine()
    {
        while (true)
        {
            gameOverText.text = "YOU DIED!";
            yield return new WaitForSeconds(0.5f);
            gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ReturnToMainMenu()
    { 
            SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit(); 
    }

}
