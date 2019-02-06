using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button startButton;
    public Text scoreText;
    public Text winText;
    public GameObject level0Prefab;
    private int currentScore = 0; 
    private GameObject level;


	void Start()
    {
        winText.gameObject.SetActive(false);
    }

	void Update()
	{
        if (!GameObject.Find("PlayerShip")) {
            Destroy(level);
            startButton.gameObject.SetActive(true);
        }
        else {
            int numAsteroids = FindObjectsOfType<Asteroid>().Length;

            if (numAsteroids == 0)
            {

                winText.gameObject.SetActive(true);
                Destroy(level);
                startButton.gameObject.SetActive(true);
            } 
        }
	}

    public void AddScore(int score) {
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }

    public void ClickStart() {
        level = Instantiate(level0Prefab, Vector3.zero, Quaternion.identity);
        winText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }
}
