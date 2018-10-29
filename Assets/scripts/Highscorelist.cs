using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Highscorelist : MonoBehaviour {

    Text HighScoreText;

    void OnEnable()
    {
        ViewHighSchool();
    }

    public void ViewHighSchool()
    {
        HighScoreText = GetComponent<Text>();
 
        HighScoreText.text = "Name: " + PlayerPrefs.GetString("HighScore1name") + " High Score: " + PlayerPrefs.GetInt("HighScore1") + 
                             "\nName: " + PlayerPrefs.GetString("HighScore2name") + " High Score: " + PlayerPrefs.GetInt("HighScore2") + 
                             "\nName: " + PlayerPrefs.GetString("HighScore3name") + " High Score: " + PlayerPrefs.GetInt("HighScore3") +
                             "\nName: " + PlayerPrefs.GetString("HighScore4name") + " High Score: " + PlayerPrefs.GetInt("HighScore4") +
                             "\nName: " + PlayerPrefs.GetString("HighScore5name") + " High Score: " + PlayerPrefs.GetInt("HighScore5") +
                             "\nName: " + PlayerPrefs.GetString("HighScore6name") + " High Score: " + PlayerPrefs.GetInt("HighScore6") +
                             "\nName: " + PlayerPrefs.GetString("HighScore7name") + " High Score: " + PlayerPrefs.GetInt("HighScore7") +
                             "\nName: " + PlayerPrefs.GetString("HighScore8name") + " High Score: " + PlayerPrefs.GetInt("HighScore8") +
                             "\nName: " + PlayerPrefs.GetString("HighScore9name") + " High Score: " + PlayerPrefs.GetInt("HighScore9").ToString();
    }
}
