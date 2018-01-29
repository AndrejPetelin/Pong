using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    Rigidbody2D rigidBody;

	// Use this for initialization
	void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// FixedUpdate is called once per physics engine cycle
	void FixedUpdate()
    {

	}

    public bool collides(Collider2D other)
    {
        return rigidBody.IsTouching(other);
    }

    public void reset()
    {
        transform.SetPositionAndRotation(new Vector3(), new Quaternion());
    }

    public void addForce(Vector2 impulse)
    {
        rigidBody.AddForce(impulse, ForceMode2D.Impulse);
    }

    public void setVelocity(Vector2 v)
    {
        rigidBody.velocity = v;
    }

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
    
}
