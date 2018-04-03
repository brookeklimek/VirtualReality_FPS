using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
   
    public AudioClip music;
    public Text healthText;
    public GameObject gameOverText;
    public GameObject healthCanvas;

    public Text scoreText;
    public static float healthPoints = 100;
    public static float score = 0;
    public static bool gameOver;

     void Start() {
        gameOver = false;
        if (music != null && MenuManager.playMusic) {
            StartCoroutine("AttachToListener");
        }
    }

     void Update() {
        healthText.text = "" + healthPoints + "%";

        if (healthPoints <= 0) {
            gameOver = true;
            GameManager.PauseGame();
        }

        if(gameOver) {
            gameOverText.SetActive(true);
            scoreText.text = "Score: " + score;
            healthCanvas.SetActive(false);
        }
    }

    public void Restart() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        gameOverText.SetActive(false);
    }

    public static void UpdateHealth(float hit) {
        healthPoints -= hit;
    }

    public static void PauseGame() {
        Time.timeScale = 0;
    }

    public static void AddPoint(float points) {
        score += points;
        Debug.Log(score);
    }

    
    IEnumerator AttachToListener() {
        bool setup = false;
        while (!setup) {
            AudioListener listener = GameObject.FindObjectOfType<AudioListener>();

            //if the audiolistener hasn't been set up yet,
            //wait for 100 milliseconds and try again
            if (listener == null)  {
                Debug.Log("Not attached");
                yield return new WaitForSeconds(.1f);
            }
            else {
                GameObject audioPlayer = new GameObject();
                audioPlayer.transform.SetParent(listener.transform);
                audioPlayer.AddComponent(typeof(AudioSource));

                AudioSource source = audioPlayer.GetComponent<AudioSource>();
                source.clip = music;
                source.Play();

                Debug.Log("Success!");
                setup = true; 
            }
        }
    }
}
