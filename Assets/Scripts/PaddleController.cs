/**
 * PaddleController.cs - controls the paddle
 * 
 * Part of the Paddle prefab, controls te movement and input of the paddle.
 * Uses keys, assigned via editor to move the paddle up and down.
 */

using UnityEngine;

public class PaddleController : MonoBehaviour
{
	public Vector2 velocity;
    public KeyCode keyUp;
	public KeyCode keyDown;

    // not set via editor, but can be accessed by the game controller
    public Collider2D boxCollider { get; private set; }

    Rigidbody2D rigidBody;
    Vector2 currVelocity;


    /**
     * Use this for initialization
     */
    void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();

		boxCollider = GetComponentInParent<BoxCollider2D>();
	//keyUp = gameObject.name == "Player1" ? KeyCode.W : KeyCode.UpArrow;
	//	keyDown = gameObject.name == "Player1" ? KeyCode.S : KeyCode.DownArrow;

	}


	/**
     * Update is called once per frame
     */
	void Update () {
		if (Input.GetKey (keyUp)) {
			currVelocity = velocity;
		} else if (Input.GetKey (keyDown)) {
			currVelocity = velocity * -1;
		} else {
			currVelocity.y = 0f;
		}
	}


    /**
     * FixedUpdate is called once per physics engine cycle
     */
	void FixedUpdate() {		
		rigidBody.MovePosition (rigidBody.position + currVelocity * Time.deltaTime);
	}
}
