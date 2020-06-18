using UnityEngine;
using Tools;

public class GameOverTrigger : MonoBehaviour 
{
    public GameManager GameManager;

    private void Start()
    {
        GameManager.WarnIfReferenceIsNull(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(GameManager.PlayerTag))
        {
            GameManager.GameOver();
        }
    }
    
}
