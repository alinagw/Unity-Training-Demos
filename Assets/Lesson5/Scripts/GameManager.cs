using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject planetPrefab;
    public GameObject planetTextPrefab;
    public GameObject sun;
    public bool playing { get; set; }

    public Text levelText;
    public Text scoreText;
    public Text highScoreText;
    public Text revsLeftText;
    public Text messageText;
    public GameObject planetRevsPanel;
    public GameObject startPanel;

    private int level;
    private int score;
    private int highScore = 0;
    private int totalRevs;
    private int revsLeft;
    private PlanetManager[] planets;

    void Start ()
    {
        StartGame();
    }

    void Update()
    {
        if (playing)
        {
            UpdateRevsLeft();
            CheckWin();
        }
    }

    public void StartGame ()
    {
        playing = false;
        startPanel.SetActive(true);
        level = 1;
        score = 0;
        revsLeftText.text = "Revolutions Left:";
        UpdateHighScore();
        planets = new PlanetManager[0];
    }

    public void EndGame ()
    {
        playing = false;

        messageText.text = "Final Score: " + score;
        DestroyPlanets();
    }

    public void StartLevel()
    {
        DestroyPlanets();
        UpdateHighScore();

        planets = new PlanetManager[level + 1];
        for (int i = 0; i <= level; i++)
        {
            SpawnPlanet(i);
        }

        totalRevs = level * 10;
        revsLeft = totalRevs;

        levelText.text = "Level: " + level;
        scoreText.text = "Score: " + score;
        revsLeftText.text = "Revolutions Left: " + revsLeft;

        TogglePlanetRevolve(true);
        playing = true;
    }
        
    void EndLevel ()
    {
        playing = false;
        TogglePlanetRevolve(false);

        int oldScore = score;
        score += revsLeft;

        messageText.text = "Level " + level + " Score: " + revsLeft;
        messageText.text += "\n" + oldScore + " + " + revsLeft;
        messageText.text += "\nNew Score: " + score;
        UpdateHighScore();
        messageText.gameObject.transform.parent.gameObject.SetActive(true);

        level++;

        if (level == 10)
        {
            GameObject.Find("NextLevelButton").GetComponent<Button>().interactable = false;
        }
    }

    void CheckWin ()
    {
        int planetsMatch = 0;
        if (planets[0].revolutions > 0)
        {
            for (int i = 0; i < planets.Length; i++)
            {
                if (planets[0].revolutions == planets[i].revolutions && !planets[i].revolving)
                {
                    planetsMatch++;
                }
            }
        }
        
        if (planetsMatch == planets.Length)
        {
            EndLevel();
        }
    }


    void SpawnPlanet (int num)
    {
        float radius = (num + 1) * 10f + Random.Range(8f, 15f);

        planets[num] = Instantiate(planetPrefab, sun.transform.position, Quaternion.identity).GetComponent<PlanetManager>();
        planets[num].id = num + 1;
        planets[num].radius = radius;
        planets[num].text = Instantiate(planetTextPrefab, planetRevsPanel.transform).GetComponent<Text>();
    }

    public void DestroyPlanets ()
    {
        if (planets.Length > 0)
        {
            for (int i = 0; i < planets.Length; i++)
            {
                Destroy(planets[i].text.gameObject);
                Destroy(planets[i].gameObject);
            }
        }
    }

    void UpdateRevsLeft ()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (totalRevs - planets[i].revolutions < revsLeft)
            {
                revsLeft = totalRevs - planets[i].revolutions;
            }
        }
        revsLeftText.text = "Revolutions Left: " + revsLeft;
    }

    void TogglePlanetRevolve (bool on)
    {
        for (int i = 0; i < planets.Length; i++)
        {
            planets[i].revolving = on;
        }
    }

    void UpdateHighScore ()
    {
        if (score > highScore)
        {
            highScore = score;
        }
        highScoreText.text = "High Score: " + highScore;
    }

}
