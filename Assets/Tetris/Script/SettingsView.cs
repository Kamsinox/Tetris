using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Tomino;

public class SettingsView : MonoBehaviour
{
    public Text titleText;
    public Toggle musicToggle;
    public Toggle soundToggle;
    public Toggle screenButtonsToggle;
    public Button closeButton;
    
    public AudioPlayer audioPlayer;
    public Font fontType;

    private UnityAction onCloseCallback;

    private void Awake()
    {
        titleText.text = Constant.Text.Settings;
        titleText.font = fontType;

        musicToggle.isOn = Settings.MusicEnabled;
        musicToggle.GetComponentInChildren<Text>().text = Constant.Text.Music;
        musicToggle.GetComponentInChildren<Text>().font = fontType;
        musicToggle.onValueChanged.AddListener((enabled) =>
        {
            Settings.MusicEnabled = enabled;
            PlayToggleAudioClip(enabled);
        });


        soundToggle.isOn = Settings.SoundEnabled;
        soundToggle.GetComponentInChildren<Text>().text = Constant.Text.Sound;
        soundToggle.GetComponentInChildren<Text>().font = fontType;
        soundToggle.onValueChanged.AddListener((enabled) =>
        {
            Settings.SoundEnabled = enabled;
            PlayToggleAudioClip(enabled);
        });

        screenButtonsToggle.isOn = Settings.ScreenButonsEnabled;
        screenButtonsToggle.GetComponentInChildren<Text>().text = Constant.Text.ScreenButtons;
        screenButtonsToggle.GetComponentInChildren<Text>().font = fontType;
        screenButtonsToggle.onValueChanged.AddListener((enabled) =>
        {
            Settings.ScreenButonsEnabled = enabled;
            PlayToggleAudioClip(enabled);
        });


        closeButton.GetComponentInChildren<Text>().text = Constant.Text.Close;
        closeButton.GetComponentInChildren<Text>().font = fontType;
        closeButton.onClick.AddListener(() =>
        {
            Hide();
            onCloseCallback.Invoke();
        });

        closeButton.gameObject.GetComponent<PointerHandler>().onPointerDown.AddListener(() =>
        {
            audioPlayer.PlayResumeClip();
        });

        Hide();
    }

    public void Show(UnityAction onCloseCallback)
    {
        this.onCloseCallback = onCloseCallback;
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
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
}
