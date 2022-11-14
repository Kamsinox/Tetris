using UnityEngine;
using Tomino;

public class GameController : MonoBehaviour
{
    public Camera currentCamera;
    public Game game;
    public BoardView boardView;
    public PieceView nextPieceView;
    public ScoreView scoreView;
    public LevelView levelView;
    public AlertView alertView;
    public SettingsView settingsView;
    public AudioPlayer audioPlayer;
    public GameObject screenButtons;

    public AudioSource musicAudioSource;
    public AudioSource soundAudioSource;
    
    public SwitchSceneManager menuManager;
    private UniversalInput universalInput;

    private bool firsttime = true;

    private void Awake()
    {
        HandlePlayerSettings();
        Settings.ChangedEvent += HandlePlayerSettings;
    }

    void Start()
    {
        Board board = new Board(10, 20);

        boardView.SetBoard(board);
        nextPieceView.SetBoard(board);

        universalInput = new UniversalInput(new KeyboardInput(), boardView.touchInput);

        game = new Game(board, universalInput);
        game.FinishedEvent += OnGameFinished;
        game.PieceFinishedFallingEvent += audioPlayer.PlayPieceDropClip;
        game.PieceRotatedEvent += audioPlayer.PlayPieceRotateClip;
        game.PieceMovedEvent += audioPlayer.PlayPieceMoveClip;
        game.Start();

        scoreView.game = game;
        levelView.game = game;
        game.Pause();
    }

    public void resumeGame()
    {
        if(firsttime) game.Resume();
        firsttime = false;
    }

    public void OnPauseButtonTap()
    {
        game.Pause();
        ShowPauseView();
    }

    public void OnMoveLeftButtonTap()
    {
        game.SetNextAction(PlayerAction.MoveLeft);
    }

    public void OnMoveRightButtonTap()
    {
        game.SetNextAction(PlayerAction.MoveRight);
    }

    public void OnMoveDownButtonTap()
    {
        game.SetNextAction(PlayerAction.MoveDown);
    }

    public void OnFallButtonTap()
    {
        game.SetNextAction(PlayerAction.Fall);
    }

    public void OnRotateButtonTap()
    {
        game.SetNextAction(PlayerAction.Rotate);
    }

    void OnGameFinished()
    {
        alertView.SetTitle(Constant.Text.GameFinished);
        alertView.AddButton(Constant.Text.PlayAgain, game.Start, audioPlayer.PlayNewGameClip);
        alertView.AddButton(Constant.Text.MainMenu, menuManager.loadMainMenu, audioPlayer.PlayNewGameClip);
        alertView.Show();
    }

    void Update()
    {
        game.Update(Time.deltaTime);
    }

    void ShowPauseView()
    {
        alertView.SetTitle(Constant.Text.GamePaused);
        alertView.AddButton(Constant.Text.Resume, game.Resume, audioPlayer.PlayResumeClip);
        alertView.AddButton(Constant.Text.NewGame, game.Start, audioPlayer.PlayNewGameClip);
        alertView.AddButton(Constant.Text.Settings, ShowSettingsView, audioPlayer.PlayResumeClip);        
        alertView.AddButton(Constant.Text.MainMenu, menuManager.loadMainMenu, audioPlayer.PlayPauseClip);
        alertView.Show();
    }

    void ShowSettingsView()
    {
        settingsView.Show(ShowPauseView);
    }

    void HandlePlayerSettings()
    {
        screenButtons.SetActive(Settings.ScreenButonsEnabled);
        boardView.touchInput.Enabled = !Settings.ScreenButonsEnabled;
        musicAudioSource.gameObject.SetActive(Settings.MusicEnabled);

        //sound effect on/off
        if(Settings.SoundEnabled) soundAudioSource.GetComponent<AudioSource>().mute = false;
        else soundAudioSource.GetComponent<AudioSource>().mute = true;
    }
}
