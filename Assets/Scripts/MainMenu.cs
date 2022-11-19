using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI newGameText;
    
    
    void Start()
    {
        StartCoroutine(newGameTextRoutine());  
    }   
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator newGameTextRoutine()
    {
        while (true)
        {
            newGameText.text = "PRESS THE START BUTTON";
            yield return new WaitForSeconds(0.5f);
            newGameText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

}
