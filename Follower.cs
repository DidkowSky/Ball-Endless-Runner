using UnityEngine;
using Tools;

public class Follower : MonoBehaviour 
{
    public bool GamePlayMode = false;
    public GameObject Player;
    public Vector3 StartingPosition = new Vector3(0, 1, -10);
    public Vector3 Offset;

    private void Start()
    {
        Player.WarnIfReferenceIsNull(gameObject);
    }

    void Update() 
    {
        if (Player != null && GamePlayMode)
            transform.position = Vector3.Lerp(transform.position, Player.transform.position + Offset, Time.deltaTime);
	}

    public void RestartPosition()
    {
        transform.position = StartingPosition;
    }
}
