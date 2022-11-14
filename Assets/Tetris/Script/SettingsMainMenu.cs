using UnityEngine;
using UnityEngine.UI;
using Tomino;
using TMPro;

public class SettingsMainMenu : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle soundToggle;
    public AudioPlayer audioPlayer;
    public TextMeshProUGUI clearHisotryText;

    private int chosenSet;

    void Start()
    {
        checkPlayerPrefs();
    }

    void Awake()
    {
        musicToggle.onValueChanged.AddListener((enabled) =>
        {
            Settings.MusicEnabled = enabled;
            PlayToggleAudioClip(enabled);
        });

        soundToggle.onValueChanged.AddListener((enabled) =>
        {
            Settings.SoundEnabled = enabled;
            PlayToggleAudioClip(enabled);
        });
    }

    private void checkPlayerPrefs()
    {
        musicToggle.isOn = Settings.MusicEnabled;
        soundToggle.isOn = Settings.SoundEnabled;
    }

    private void PlayToggleAudioClip(bool enabled)
    {
        if (enabled)
        {
            audioPlayer.PlayToggleOnClip();
        }
        else
        {
            audioPlayer.PlayToggleOffClip();
        }
    }

    public void resetScore()
    {
        PlayerPrefs.GetInt("maxscore");
        PlayerPrefs.GetInt("maxlevel");
        PlayerPrefs.GetInt("maxlines");
        PlayerPrefs.GetInt("maxtetris");

        PlayerPrefs.SetInt("maxscore", 0);
        PlayerPrefs.SetInt("maxlevel", 0);
        PlayerPrefs.SetInt("maxlines", 0);
        PlayerPrefs.SetInt("maxtetris", 0);
        PlayerPrefs.Save();
        clearHisotryText.text = "Cleared X_X";
    }
}
