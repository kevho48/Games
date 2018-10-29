using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // need this because of Text sxoreText

public class GameManager : MonoBehaviour {

    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;

    public static GameManager Instance; //if GameManager.Instance, then code can access all public methods in this class.

    public AudioClip[] stings;
    public AudioSource stingSource;

    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject countdownPage;
    public GameObject highscorePage;
    public Text scoreText;
    public Text WarpIndicator;
    public InputField scoreName;

    enum PageState {
        None,
        Start,
        GameOver,
        Countdown,
        Highscore
    }

    int score = 0;
    bool gameOver = true;

    public bool GameOver { get { return gameOver; } }
    public int Score { get { return score; } }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable()
    {
        CountdownText.OnCountdownFinished += OnCountdownFinished;
        TapController.OnPlayerDied += OnPlayerDied;
        TapController.OnPlayerScored += OnPlayerScored;
        BulletScript.OnPlayerScored += OnPlayerScored;
        WaveGenerator.OnPlayerScored += OnPlayerScored;

    }

    void OnDisable()
    {
        CountdownText.OnCountdownFinished -= OnCountdownFinished;
        TapController.OnPlayerDied -= OnPlayerDied;
        TapController.OnPlayerScored -= OnPlayerScored;
        BulletScript.OnPlayerScored -= OnPlayerScored;
        WaveGenerator.OnPlayerScored -= OnPlayerScored;
    }

    void OnCountdownFinished() {
        SetPageState(PageState.None);
        OnGameStarted();    //event is sent to tapcontroller
        score = 0;
        gameOver = false;
    }

    void OnPlayerDied() {
        gameOver = true; 
        SetPageState(PageState.GameOver);
    }

    void OnPlayerScored()
    {
        score++;
        scoreText.text = score.ToString();
    }

    void SetPageState(PageState state) { //controls which pages are active 
        switch (state) {
            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                highscorePage.SetActive(false);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                highscorePage.SetActive(false);
                stingSource.clip = stings[Random.Range(0,2)];
                stingSource.Play();
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                countdownPage.SetActive(false);
                highscorePage.SetActive(false);
                break;
            case PageState.Countdown:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(true);
                highscorePage.SetActive(false);
                scoreText.GetComponent<Text>().enabled = true;
                WarpIndicator.GetComponent<Text>().enabled = true;
                break;
            case PageState.Highscore:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                highscorePage.SetActive(true);
                scoreText.GetComponent<Text>().enabled = false;
                WarpIndicator.GetComponent<Text>().enabled = false;
                break;
        }
    }
    public void Highscore() {
        //activited when play button is hit
        int savedScore1 = PlayerPrefs.GetInt("HighScore1");
        int savedScore2 = PlayerPrefs.GetInt("HighScore2");
        int savedScore3 = PlayerPrefs.GetInt("HighScore3");
        int savedScore4 = PlayerPrefs.GetInt("HighScore4");
        int savedScore5 = PlayerPrefs.GetInt("HighScore5");
        int savedScore6 = PlayerPrefs.GetInt("HighScore6");
        int savedScore7 = PlayerPrefs.GetInt("HighScore7");
        int savedScore8 = PlayerPrefs.GetInt("HighScore8");
        int savedScore9 = PlayerPrefs.GetInt("HighScore9");
        if (score > savedScore1)
        {
            PlayerPrefs.SetInt("HighScore1", score);
            PlayerPrefs.SetInt("HighScore2", savedScore1);
            PlayerPrefs.SetInt("HighScore3", savedScore2);
            PlayerPrefs.SetInt("HighScore4", savedScore3);
            PlayerPrefs.SetInt("HighScore5", savedScore4);
            PlayerPrefs.SetInt("HighScore6", savedScore5);
            PlayerPrefs.SetInt("HighScore7", savedScore6);
            PlayerPrefs.SetInt("HighScore8", savedScore7);
            PlayerPrefs.SetInt("HighScore9", savedScore8);
            PlayerPrefs.SetString("HighScore9name", PlayerPrefs.GetString("HighScore8name"));
            PlayerPrefs.SetString("HighScore8name", PlayerPrefs.GetString("HighScore7name"));
            PlayerPrefs.SetString("HighScore7name", PlayerPrefs.GetString("HighScore6name"));
            PlayerPrefs.SetString("HighScore6name", PlayerPrefs.GetString("HighScore5name"));
            PlayerPrefs.SetString("HighScore5name", PlayerPrefs.GetString("HighScore4name"));
            PlayerPrefs.SetString("HighScore4name", PlayerPrefs.GetString("HighScore3name"));
            PlayerPrefs.SetString("HighScore3name", PlayerPrefs.GetString("HighScore2name"));
            PlayerPrefs.SetString("HighScore2name", PlayerPrefs.GetString("HighScore1name"));
        }
        else if (score > savedScore2)
        {
            PlayerPrefs.SetInt("HighScore2", score);
            PlayerPrefs.SetInt("HighScore3", savedScore2);
            PlayerPrefs.SetInt("HighScore4", savedScore3);
            PlayerPrefs.SetInt("HighScore5", savedScore4);
            PlayerPrefs.SetInt("HighScore6", savedScore5);
            PlayerPrefs.SetInt("HighScore7", savedScore6);
            PlayerPrefs.SetInt("HighScore8", savedScore7);
            PlayerPrefs.SetInt("HighScore9", savedScore8);
            PlayerPrefs.SetString("HighScore9name", PlayerPrefs.GetString("HighScore8name"));
            PlayerPrefs.SetString("HighScore8name", PlayerPrefs.GetString("HighScore7name"));
            PlayerPrefs.SetString("HighScore7name", PlayerPrefs.GetString("HighScore6name"));
            PlayerPrefs.SetString("HighScore6name", PlayerPrefs.GetString("HighScore5name"));
            PlayerPrefs.SetString("HighScore5name", PlayerPrefs.GetString("HighScore4name"));
            PlayerPrefs.SetString("HighScore4name", PlayerPrefs.GetString("HighScore3name"));
            PlayerPrefs.SetString("HighScore3name", PlayerPrefs.GetString("HighScore2name"));
        }
        else if (score > savedScore3)
        {
            PlayerPrefs.SetInt("HighScore3", score);
            PlayerPrefs.SetInt("HighScore4", savedScore3);
            PlayerPrefs.SetInt("HighScore5", savedScore4);
            PlayerPrefs.SetInt("HighScore6", savedScore5);
            PlayerPrefs.SetInt("HighScore7", savedScore6);
            PlayerPrefs.SetInt("HighScore8", savedScore7);
            PlayerPrefs.SetInt("HighScore9", savedScore8);
            PlayerPrefs.SetString("HighScore9name", PlayerPrefs.GetString("HighScore8name"));
            PlayerPrefs.SetString("HighScore8name", PlayerPrefs.GetString("HighScore7name"));
            PlayerPrefs.SetString("HighScore7name", PlayerPrefs.GetString("HighScore6name"));
            PlayerPrefs.SetString("HighScore6name", PlayerPrefs.GetString("HighScore5name"));
            PlayerPrefs.SetString("HighScore5name", PlayerPrefs.GetString("HighScore4name"));
            PlayerPrefs.SetString("HighScore4name", PlayerPrefs.GetString("HighScore3name"));
        }
        else if (score > savedScore4)
        {
            PlayerPrefs.SetInt("HighScore4", score);
            PlayerPrefs.SetInt("HighScore5", savedScore4);
            PlayerPrefs.SetInt("HighScore6", savedScore5);
            PlayerPrefs.SetInt("HighScore7", savedScore6);
            PlayerPrefs.SetInt("HighScore8", savedScore7);
            PlayerPrefs.SetInt("HighScore9", savedScore8);
            PlayerPrefs.SetString("HighScore9name", PlayerPrefs.GetString("HighScore8name"));
            PlayerPrefs.SetString("HighScore8name", PlayerPrefs.GetString("HighScore7name"));
            PlayerPrefs.SetString("HighScore7name", PlayerPrefs.GetString("HighScore6name"));
            PlayerPrefs.SetString("HighScore6name", PlayerPrefs.GetString("HighScore5name"));
            PlayerPrefs.SetString("HighScore5name", PlayerPrefs.GetString("HighScore4name"));
        }
        else if (score > savedScore5)
        {
            PlayerPrefs.SetInt("HighScore5", score);
            PlayerPrefs.SetInt("HighScore6", savedScore5);
            PlayerPrefs.SetInt("HighScore7", savedScore6);
            PlayerPrefs.SetInt("HighScore8", savedScore7);
            PlayerPrefs.SetInt("HighScore9", savedScore8);
            PlayerPrefs.SetString("HighScore9name", PlayerPrefs.GetString("HighScore8name"));
            PlayerPrefs.SetString("HighScore8name", PlayerPrefs.GetString("HighScore7name"));
            PlayerPrefs.SetString("HighScore7name", PlayerPrefs.GetString("HighScore6name"));
            PlayerPrefs.SetString("HighScore6name", PlayerPrefs.GetString("HighScore5name"));
        }
        else if (score > savedScore6)
        {
            PlayerPrefs.SetInt("HighScore6", score);
            PlayerPrefs.SetInt("HighScore7", savedScore6);
            PlayerPrefs.SetInt("HighScore8", savedScore7);
            PlayerPrefs.SetInt("HighScore9", savedScore8);
            PlayerPrefs.SetString("HighScore9name", PlayerPrefs.GetString("HighScore8name"));
            PlayerPrefs.SetString("HighScore8name", PlayerPrefs.GetString("HighScore7name"));
            PlayerPrefs.SetString("HighScore7name", PlayerPrefs.GetString("HighScore6name"));
        }
        else if (score > savedScore7)
        {
            PlayerPrefs.SetInt("HighScore7", score);
            PlayerPrefs.SetInt("HighScore8", savedScore7);
            PlayerPrefs.SetInt("HighScore9", savedScore8);
            PlayerPrefs.SetString("HighScore9name", PlayerPrefs.GetString("HighScore8name"));
            PlayerPrefs.SetString("HighScore8name", PlayerPrefs.GetString("HighScore7name"));
        }
        else if (score > savedScore8)
        {
            PlayerPrefs.SetInt("HighScore8", score);
            PlayerPrefs.SetInt("HighScore9", savedScore8);
            PlayerPrefs.SetString("HighScore9name", PlayerPrefs.GetString("HighScore8name"));
        }
        else if (score > savedScore9)
        {
            PlayerPrefs.SetInt("HighScore9", score);
        }
        //******************************************************************
        string name = scoreName.text.ToString();
        if (score == PlayerPrefs.GetInt("HighScore9"))
        {
            PlayerPrefs.SetString("HighScore9name", name);
        }
        else if (score == PlayerPrefs.GetInt("HighScore8"))
        {
            PlayerPrefs.SetString("HighScore8name", name);
        }
        else if (score == PlayerPrefs.GetInt("HighScore7"))
        {
            PlayerPrefs.SetString("HighScore7name", name);
        }
        else if (score == PlayerPrefs.GetInt("HighScore6"))
        {
            PlayerPrefs.SetString("HighScore6name", name);
        }
        else if (score == PlayerPrefs.GetInt("HighScore5"))
        {
            PlayerPrefs.SetString("HighScore5name", name);
        }
        else if (score == PlayerPrefs.GetInt("HighScore4"))
        {
            PlayerPrefs.SetString("HighScore4name", name);
        }
        else if (score == PlayerPrefs.GetInt("HighScore3"))
        {
            PlayerPrefs.SetString("HighScore3name", name);
        }
        else if (score == PlayerPrefs.GetInt("HighScore2"))
        {
            PlayerPrefs.SetString("HighScore2name", name);
        }
        else if (score == PlayerPrefs.GetInt("HighScore1"))
        {
            PlayerPrefs.SetString("HighScore1name", name);
        }
        //PlayerPrefs.DeleteAll();
        ConfirmedGameOver();
    }

    public void Quit()
    {
        print("quit");
        Application.Quit();
    }

    public void HighscoreMenu()
    {
        //activited when play button is hit
        SetPageState(PageState.Highscore);
    }

    public void ConfirmedGameOver() {
        //activied when replay button is hit
        OnGameOverConfirmed(); //event is sent to tapcontroller
        SetPageState(PageState.Start);
        scoreText.text = "0";
    }

    public void StartGame() {
        //activited when play button is hit
        SetPageState(PageState.Countdown); 
    }
}
