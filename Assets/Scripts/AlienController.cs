using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlienController : MonoBehaviour
{
    public float speed = 0.0f;

    float timeRemaining = 12.0f;

    public int scoreValue = 0;
    public int timeInt;
    private int stopperInt = 0;
    private int resetOption = 0;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public Text score;
    public Text gameOver;
    public Text timer;

    public AudioClip bgMusic;
    public AudioClip winMusic;
    public AudioClip loseMusic;
    public AudioSource musicPlayer;

    public GameObject pickUp;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        score.text = "Stars Collected: " + scoreValue.ToString();
        gameOver.text = "";
        timer.text = "Time Remaining: " + timeInt.ToString();

        musicPlayer.clip = bgMusic;
        musicPlayer.Play();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
       
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (timeRemaining < 20)
        {
            timeRemaining -= 1 * Time.deltaTime;
            timeInt = Mathf.RoundToInt(timeRemaining);
        }
        if(timeInt < 11)
        {
            speed = 5.0f;
        }

        if(timeRemaining < 0)
        {
            stopperInt = 1;
            timeRemaining = 300;
            EndMusic();
        }

        if(stopperInt == 1)
        {
            speed = 0;
        }

        if(resetOption == 1)
        {
            if(Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
        }

        timer.text ="Time Remaining: " + timeInt.ToString();
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeScore(int starCollect)
    {
        scoreValue = scoreValue + starCollect;
        score.text = "Stars Collected: " + scoreValue.ToString();
         GameObject starEffect = Instantiate(pickUp, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void EndMusic()
    {
            if(scoreValue < 7)
            {
                musicPlayer.clip = loseMusic;
                musicPlayer.Play();

                gameOver.text = "You lose! Press R to restart.";

                resetOption = 1;
            }

            if(scoreValue == 7)
            {
                musicPlayer.clip = winMusic;
                musicPlayer.Play();

                gameOver.text = "You win! Press R to restart.";

                resetOption = 1;
            }
    }
}
