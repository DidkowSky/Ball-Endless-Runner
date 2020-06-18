using UnityEngine;

public class UIRoot : MonoBehaviour 
{
    public GameObject MenuView;
    public GameObject GameView;
    public GameObject GameOverView;
    public GameObject TrackView;

    public void StartGame()
    {
        MenuView.SetActive(false);
        GameView.SetActive(true);
    }

    public void MainMenu() 
    {
        GameOverView.SetActive(false);
        TrackView.SetActive(false);
        MenuView.SetActive(true);
    }

    public void TrackViewMenu()
    {
        MenuView.SetActive(false);
        TrackView.SetActive(true);
    }

    public void GameOver()
    {
        GameView.SetActive(false);
        GameOverView.SetActive(true);
    }
}
