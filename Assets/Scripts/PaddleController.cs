using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public Collider2D boxCollider { get; private set; }

	// Use this for initialization
	void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponentInParent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
