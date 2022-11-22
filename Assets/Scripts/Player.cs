using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using StarterAssets;

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
    private int minScore;
    public int highScore;
    private Animator animator;
    public AudioClip playerDeathSound;
    public AudioClip playerDamageSound;
    private AudioSource audioSource;
    private ThirdPersonController playerController;
    
    
    

    void Start()
    {
        playerController = GetComponent<ThirdPersonController>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        scoreText.text = "Score: " + 0;
        animator = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        minScore = 0;
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
        currentHealth = Mathf.Max(0, currentHealth);
    }


    void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                audioSource.clip = playerDamageSound;
                audioSource.PlayOneShot(playerDamageSound);
                TakeDamage(20); 
                TakeScore(10);
                percentText.text = currentHealth.ToString() + "%";
    
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
        if (score >= minScore)
        {
            scoreText.text = "Score:" + playerScore.ToString();
        }

        score = Mathf.Max(0, score);

    }


    public void AddScore(int points)
    {  
        score += points;
        UpdateScore(score);
    }

    public void TakeScore(int substractpoints)
    {
        score -= substractpoints;
        UpdateScore(score);
    }


    void OnPlayerDeath()
    {
        if (currentHealth <= 0)
        {
            if (PlayerPrefs.GetInt("HighScore") < score) 
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            animator.SetTrigger("OnPlayerDeath");
            audioSource.PlayOneShot(playerDeathSound);
            playerController.enabled = false;
        }

    }


    IEnumerator GameOver()
    {
        if (currentHealth <= 0)
        {
            yield return new WaitForSeconds(5);        
            SceneManager.LoadScene(2);
        }
        
    }


}
