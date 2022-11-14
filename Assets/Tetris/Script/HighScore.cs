using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI highLevelText;
    public TextMeshProUGUI highLinesText;
    public TextMeshProUGUI tetrisesText;

    void Update()
    {
        showStats();
    }

    public void showStats()
    {
        highScoreText.text = PlayerPrefs.GetInt("maxscore").ToString();
        highLevelText.text = PlayerPrefs.GetInt("maxlevel").ToString();
        highLinesText.text = PlayerPrefs.GetInt("maxlines").ToString();
        tetrisesText.text = PlayerPrefs.GetInt("maxtetris").ToString();
    }
}
