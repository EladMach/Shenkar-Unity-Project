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
        ReturnToMainMenu();
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

    void ReturnToMainMenu()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
    }

}
