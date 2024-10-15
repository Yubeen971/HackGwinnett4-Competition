
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Vector2 startPos; 
    public AudioSource UI;
    public AudioSource FemaleDie;
    public AudioSource won;
    public Animator animator; 
    public GameObject gameOverUI;
    public GameObject WonUI;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Back();
        }

        if (collision.CompareTag("Portal"))
        {
            SceneManager.LoadScene("Game");
        }

        if (collision.CompareTag("Enime"))
        {
            animator.SetTrigger("Die");
            FemaleDie.Play();
            Invoke("Die", 1f);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            
        }

        if (collision.CompareTag("won"))
        {
            Won();
        }
        if (collision.CompareTag("Portal 2"))
        {
            SceneManager.LoadScene("Game 2");
        }
        
        if (collision.CompareTag("Portal 3"))
        {
            SceneManager.LoadScene("Game 3");
        }
        if (collision.CompareTag("Portal 4"))
        {
            SceneManager.LoadScene("Game 4");
        }
    }

    void Back()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = startPos;
    }
    void Die()
    {
        
        UI.Play();
        Destroy(gameObject);
        gameOver();
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Won()
    {
        won.Play();
        WonUI.SetActive(true);
    }
}
