using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState { start, serve, play, done }

public class Main : MonoBehaviour
{
	public PaddleController player1 = null;
	public PaddleController player2 = null;
	public BallController ball = null;


	int player1score = 0;
	int player2score = 0;
	int servingPlayer = 1;
	int winningPlayer = 0;

	// BallController ballCtrl;

	GameState gameState = GameState.start;

	// Use this for initialization
	void Awake()
	{
		// ballCtrl = ball.GetComponent<BallController>();

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (gameState == GameState.start)
		{
			// begin game when enter key pressed
			if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
			{
				gameState = GameState.serve;
			}
		}
		else if (gameState == GameState.serve)
		{
            // serve ball on enter key pressed
            if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
            {
                // before switching to play, initialize ball's velocity and direction
                // TODO: consider breaking down speed into x and y components
                // originally in Colton's Pong speed is broken down into x and y,
                // see if this should be applied here (overloaded function already in BallController)
                float v = Helpers.random(1.4f, 2.0f);
                float a = Helpers.random(-45.0f, 45.0f);
                //float a = 0f;
                // reverse direction if player 2 is serving
                if (servingPlayer != 1)
                {
                    v *= -1.0f;
                }

                ball.setVelocity(v, a);
                gameState = GameState.play;
            }
		}
		/*else if (gameState == GameState.play)
        {
            // TODO: physics handling - decide on how much to handle manually and what to leave to Unity
            // we're handling physics kind of manually here. We're setting direction and velocity manually,
            // we're manually detecting collision, but unlike Colton's Lua+Löve2D version we're not actually
            // handling the per-frame location of the ball, we're leaving that to Unity.

            if (ball.collides(player1.boxCollider) || ball.collides(player2.boxCollider))
            {
                Vector2 velocity = ball.getVelocity();
                velocity.x *= -1.0f;
                ball.setVelocity(velocity * 1.03f);
            }
        }

	}*/
	}

    void goalHit(string goal)
    {
        if (goal == "GoalPlayer1")
        {
            ++player2score;    
            servingPlayer = 1;
        }
        else
        {
            ++player1score;
            servingPlayer = 2;
        }

        ball.reset();
        gameState = GameState.serve;

        if (player1score == 10 || player2score == 10) gameState = GameState.done;
    }
}
