/**
 * BallController.cs - controll script for the ball object.
 * 
 * Exposes the functions of the Transform and RigidBody to the game controller
 */


using UnityEngine;

public class BallController : MonoBehaviour {
    Rigidbody2D rigidBody;
    GameObject gameController;


	/**
     * Use this for initialization
     */
	void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
	}
	

	/**
     * FixedUpdate is called once per physics engine cycle
     */
	void FixedUpdate()
    {

	}


    /**
     * check for collision with the specified collider
     */
    public bool collides(Collider2D other)
    {
        return rigidBody.IsTouching(other);
    }


    /**
     * returns the ball to starting position (0, 0) and sets velocity to 0.
     */
    public void reset()
    {
        transform.SetPositionAndRotation(new Vector3(), new Quaternion());
        setVelocity(new Vector2());
    }


    /**
     * add a one-time force impulse to the ball
     */
    public void addImpulse(Vector2 impulse)
    {
        rigidBody.AddForce(impulse, ForceMode2D.Impulse);
    }


    /**
     * set velocity of the ball per coordinate
     */
    public void setVelocity(Vector2 v)
    {
        rigidBody.velocity = v;
    }


    /**
     * overloaded setVelocity, takes absolute velocity and angle
     */
    public void setVelocity(float v, float ang)
    {
        float vx = v * Mathf.Cos(ang * Mathf.Deg2Rad);
        float vy = v * Mathf.Sin(ang * Mathf.Deg2Rad);
        setVelocity(new Vector2(vx, vy));
    }


    public Vector2 getVelocity()
    {
        return rigidBody.velocity;
    }


    /**
     * when collision detected calls gameController.goalHit(collision.name) function via message
     */
    public void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.SendMessage("goalHit", collision.name);
    }

}
