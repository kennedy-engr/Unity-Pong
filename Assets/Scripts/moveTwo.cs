using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTwo : MonoBehaviour
{
    /* Public Variables */
    public Rigidbody twoPaddle;
    public Ball myBall;

    /* Private Variables */ 
    private float stayValue;
    private float speed = 150f;
    private bool twoUpPress;
    private bool twoDownPress;

    /* Start
     * Description: Initialize player two paddle on
     *              the inspector.
     */
    void Start()
    {
        twoPaddle = GetComponent<Rigidbody>();
    }

    /* Update
     * Description: if the user chose a two Player game, then a user controls
     *              the player 2 paddle. If the player chose a one player game, 
     *              then the player 2 paddle is controlled by a "computer." 
     */
    void Update()
    {
        if (mainMenu.twoPlayer) // Two player game chosen
        {
            speed = 300f;
            twoUpPress = Input.GetKey(KeyCode.UpArrow);
            twoDownPress = Input.GetKey(KeyCode.DownArrow);
            playerTwoMove();
        }
        else // One player game chosen
        {
            speed = 150f;
            cpuMove();
        }
    }

    /* playerTwoMove
     * Description: similar to playerOneMove in class moveOne
     */
    private void playerTwoMove()
    {
        if (twoUpPress)
        {
            twoPaddle.velocity = new Vector3(0f, speed, 0f);
        }
        else if (twoDownPress)
        {
            twoPaddle.velocity = new Vector3(0f, speed * -1, 0f);
        }
        else
        {
            twoPaddle.velocity = new Vector3(0f, 0f, 0f);
        }
    }

    /* cpuMove
     * Description: this is the computer control for paddle two. There are two
     *              separate movement options. Both use the location of the paddle
     *              relative to the location of the ball. Option one tries to center 
     *              the ball in the middle of the paddle whilst strafing back and forth.
     *              Option two looks at when the ball travels at an extreme angle (>100)
     *              and shoots the paddle in that direction to try to catch it. 
     */
    private void cpuMove()
    {

        Vector3 ballPosition = myBall.ballObject.transform.position;        // ball located 
        Vector3 paddlePosition = twoPaddle.gameObject.transform.position;   // paddle located
     
        if (Mathf.Abs(myBall.getAngle()) > 100) // extreme angle case 
        {
            if (myBall.getAngle() < 0)
            {
                twoPaddle.velocity = new Vector3(0f, speed * -1, 0f);
            }
            if (myBall.getAngle() > 0)
            {
                twoPaddle.velocity = new Vector3(0f, speed, 0f);
            }
        }
        else // normal case
        {
            if (paddlePosition.y < ballPosition.y - 50) // move until the paddle position is slightly greater thatn the required then move back ( overshoot it )
            {
                twoPaddle.velocity = new Vector3(0f, speed, 0f);
            }
            else if (paddlePosition.y > ballPosition.y + 50)
            {
                twoPaddle.velocity = new Vector3(0f, speed * -1, 0f);
            }
        }
    }

    // adjust speed, angle, paddlespeed , max speed etc numbers !
}
