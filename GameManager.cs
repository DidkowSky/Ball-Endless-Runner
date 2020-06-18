using UnityEngine;
using Tools;

public class GameManager : MonoBehaviour 
{
    private string playerTag = "Player";
    public string PlayerTag
    {
        get { return playerTag; }
    }

    private bool gamePlayMode = false;
    public bool GamePlayMode
    {
        get { return gamePlayMode; }
        set
        {
            if (gamePlayMode != value)
            {
                gamePlayMode = value;

                if (PlayerFollower != null)
                {
                    PlayerFollower.GamePlayMode = value;
                }
            }
        }
    }

    public UIRoot UI;
    public TrackManager TrackManagerComponent;
    public BallMovement BallMovementComponent;
    public Follower PlayerFollower;

    public Camera GameViewCamera;
    public Camera TrackViewCamera;

    void Start () 
    {
        UI.WarnIfReferenceIsNull(gameObject);
        TrackManagerComponent.WarnIfReferenceIsNull(gameObject);
        BallMovementComponent.WarnIfReferenceIsNull(gameObject);
        PlayerFollower.WarnIfReferenceIsNull(gameObject);
        GameViewCamera.WarnIfReferenceIsNull(gameObject);
        TrackViewCamera.WarnIfReferenceIsNull(gameObject);

        if (BallMovementComponent != null)
            playerTag = BallMovementComponent.gameObject.tag;

        ShowMenu(true);
    }

    public void StartGame()
    {
        UI.StartGame();

        GamePlayMode = true;
        BallMovementComponent.StartMoving();
    }

    public void ShowMenu(bool reset = false)
    {
        GamePlayMode = false;
        TrackManagerComponent.SpawnDistance = 40;

        if (reset)
        {
            TrackManagerComponent.ResetTrack();
        
            BallMovementComponent.StopMoving();
            BallMovementComponent.RestartBallPosition();
        }

        UI.MainMenu();

        GameViewCamera.enabled = true;
        TrackViewCamera.enabled = false;
    }

    public void GameOver()
    {
        GamePlayMode = false;

        UI.GameOver();

        BallMovementComponent.StopMoving();
    }

    public void ShowTrack()
    {
        TrackManagerComponent.SpawnDistance = 160;

        UI.TrackViewMenu();

        TrackViewCamera.enabled = true;
        GameViewCamera.enabled = false;
    }

    public void ChangeTrack()
    {
        TrackManagerComponent.ResetTrack();
    }
}
