using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isPlaying = false;

    public Text lifeRemaining;

    public GameObject winPanel;

    public Text mark;

    public int lifeTimes = 1;

    public bool onceOnly = true;

    public bool scoreOnce = true;

    private bool _isPassedLevel = false;

    public bool congradsShow = false;

    public bool isProlong = false;
    public bool isPassedLevel
    {
        set
        {
            _isPassedLevel = value;

            if (_isPassedLevel)
            {
                //isPlaying = false;

                winPanel.SetActive(true);

                congradsShow = true;

                Time.timeScale = 0.25f;

                Invoke("WinStep2", 0.2f);
            }
        }

        get { return _isPassedLevel; }

    }


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        brick[] allBricks = GameManager.FindObjectsOfType<brick>();

        foreach (var item in allBricks)
        {
            if (item.currentType == brick.Brick_Type.NonBroken)
            {
                continue;
            }

            item.GetComponent<Renderer>().material.color = Random.ColorHSV();

        }


    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (congradsShow && scene.name == "Level01")
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                SceneManager.LoadScene("Level02");
            }
        }

        if (congradsShow && scene.name == "Level02")
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                SceneManager.LoadScene("Level03");
            }
        }
    }

    //public void ResetBall()
    //{
    //    isPlaying = false;
    //}

    public void GameOver()
    {
        if (lifeTimes == 0)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            ChangeLife(-1);

            isPlaying = false;

            scoreOnce = true;

            isProlong = false;

            GameObject.FindWithTag("paddle").transform.localScale = transform.localScale = new Vector3(4, 0.5f, 1);

            isProlong = false;

            onceOnly = true;
        }

    }

    public void ChangeLife(int i)
    {
        if (onceOnly)
        {
            print(lifeTimes);

            lifeTimes += i;

            print(lifeTimes);

            lifeRemaining.text = lifeTimes.ToString();

            onceOnly = false;

        }

    }

    public void CheckLevelPassed()
    {
        brick[] allBricks = GameManager.FindObjectsOfType<brick>();

        bool tempPassedLevel = true;

        foreach (var item in allBricks)
        {
            if (item.currentType == brick.Brick_Type.NonBroken)
            {
                continue;
            }

            if (item.enabled == false)
            {
                continue;
            }

            tempPassedLevel = false;
        }

        isPassedLevel = tempPassedLevel;

        if (allBricks.Length == 0)
        {
            isPassedLevel = true;
        }
        else
        {
            isPassedLevel = false;
        }
    }

    void WinStep2()
    {
        Time.timeScale = 1f;

        isPlaying = false;
    }

    public bool IslastBall
    {
        get 
        {
            ball[] allBalls = GameManager.FindObjectsOfType<ball>();

            return allBalls.Length == 1;
        }
    }
}
