using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public float flashSpeed;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public Image damageImage;
    private bool damaged;
    public Text percentText;
    public TextMeshProUGUI scoreText;
    public int score;
    private Animator animator;
 


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        scoreText.text = "Score: " + 0;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;

        OnPlayerDeath();
        StartCoroutine(GameOver());

    }



    void TakeDamage(int damage)
    {
        damaged = true;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.tag == "Enemy")
            {
                TakeDamage(20);
                percentText.text =            currentHealth.ToString() + "%";  
            }

        }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            AddScore(10);
        }    
    }

    public void UpdateScore(int playerScore)
    {
       scoreText.text = "Score:" + playerScore.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore(score);
    }

    void OnPlayerDeath()
    {
        if (currentHealth <= 0)
        {
            animator.SetTrigger("OnPlayerDeath");
        }
        
    }

    IEnumerator GameOver()
    {
        if (currentHealth <= 0)
        {
            yield return new WaitForSeconds(5);
            PlayerPrefs.SetInt("highscore", score);
            SceneManager.LoadScene(2);
        }
        
    }
    

}
