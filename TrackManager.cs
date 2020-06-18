using UnityEngine;
using Tools;

public class TrackManager : MonoBehaviour
{
    public GameObject Player;
    public LevelSegments LevelSegments;

    public float SpawnDistance = 40;
    public float CurrentSegmentPosition;

    private float destructionOffset = 15;

    private void Start()
    {
        if (LevelSegments == null)
        {
            Debug.LogWarning("Missing LevelSegments reference!", this);
        }
        else
        {
            destructionOffset = 3 * LevelSegments.GetMaxForwardExtensionValue();
        }
    }

    void FixedUpdate () 
    {
		if(CurrentSegmentPosition - Player.transform.position.z < SpawnDistance)
        {
            SpawnNextSegment();
            DestroyLastSegment();            
        }
    }

    public void ResetTrack()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        CurrentSegmentPosition = -5;
    }

    private void SpawnNextSegment()
    {
        if (LevelSegments != null)
        {
            var trailSegment = LevelSegments.Segments[Random.Range(0, LevelSegments.Segments.Count)];

            if (trailSegment.SegmentObject != null)
            {
                GameObject instance = Instantiate(trailSegment.SegmentObject);
                instance.transform.SetParent(transform);

                CurrentSegmentPosition += trailSegment.ForwardExtension;
                instance.transform.position = new Vector3(0, 0, CurrentSegmentPosition);
            }
        }
    }

    private void DestroyLastSegment()
    {
        if (transform.childCount > 0)
        {
            var instance = transform.GetChild(0);

            if (Player.transform.position.z > instance.position.z + destructionOffset)
            {
                Destroy(instance.gameObject);
            }
        }
    }
}
