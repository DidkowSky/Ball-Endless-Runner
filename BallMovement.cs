using UnityEngine;
using Tools;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour 
{
    public float InputForce = 400f;
    public float MovementForce = 300f;
    public Vector3 StartingPosition = new Vector3(0, 3, 0);

    private bool movable = false;
    private Rigidbody rigidbody;
    
	void Start () 
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();

        rigidbody.WarnIfReferenceIsNull(gameObject);
	}
	
	void Update ()
    {
        if (!movable) 
            return;

        float horizontalVector = Input.GetAxis("Horizontal") * InputForce * Time.deltaTime;
        float velocity = MovementForce * Time.deltaTime;

        rigidbody.AddForce(horizontalVector, 0, velocity);
	}

    public void StartMoving()
    {
        movable = true;

        if (rigidbody != null)
        {
            rigidbody.useGravity = true;
        }
    }
    
    public void StopMoving()
    {
        movable = false;

        if (rigidbody != null)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.useGravity = false;
        }
    }

    public void RestartBallPosition()
    {
        if (rigidbody != null)
        {
            rigidbody.velocity = Vector3.zero;
            transform.position = StartingPosition;
        }
    }
}
