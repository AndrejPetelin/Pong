using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
	Rigidbody2D rigidBody;
	public Vector2 velocity;
	public Collider2D boxCollider { get; private set; }

	Vector2 currVelocity;
	public KeyCode keyUp;
	public KeyCode keyDown;

	// Use this for initialization
	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();

		boxCollider = GetComponentInParent<BoxCollider2D>();
	//keyUp = gameObject.name == "Player1" ? KeyCode.W : KeyCode.UpArrow;
	//	keyDown = gameObject.name == "Player1" ? KeyCode.S : KeyCode.DownArrow;

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (keyUp)) {
			currVelocity = velocity;
		} else if (Input.GetKey (keyDown)) {
			currVelocity = velocity * -1;
		} else {
			currVelocity.y = 0f;
		}
	}

	void FixedUpdate() {		
		rigidBody.MovePosition (rigidBody.position + currVelocity * Time.deltaTime);
	}
}
