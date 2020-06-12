using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // public variables to be set in Inspector
    public Collider playerOnePaddle;
    public Collider playerTwoPaddle;
    public GameObject ballObject;       // the game ball GO
    public Rigidbody ballBody;          // the game ball RB

    // private variables (no change)
    public float speed = 300f;
    public float angle = 0;
    private Vector3 startLocation;      // world vector of start pos

    /* Start
     * Description:
     * Sets the ballbody RB compenent to be used and gets the starting location
     * Vector3, also runs first wait when game starts. 
     * 
     * @param 
     * @return
     **/
    void Start()
    {
        ballBody = GetComponent<Rigidbody>();
        startLocation = ballObject.transform.position;
        StartCoroutine(waiter());
    }

    /* Update
     * Description: checks when to reset the ball. 
     */
    void Update()
    {
        checkResetBall();   
    }

    /* GetAngle
    * Description: a simple getter for the angle of the ball. 
    */
    public float getAngle()
    {
        return this.angle;
    }

    /* checkResetBall
    * Description: if either player scores, then the ball is reset to the center
    *              of the court (aka the startLoation). The the wait coroutine is 
    *              called and the ball is started off from there. 
    */
    public void checkResetBall()
    {
        if (playerOneGoal.reset || playerTwoGoal.reset)
        {
            angle = 0;
            speed = 0;
            ballObject.transform.position = startLocation;
            StartCoroutine(waiter());
        }

        // or game lasts too long or goal doesnt trigger ( bug check)
    }

    /* waiter
     * Description: this method is called after a goal is scored. The
     *              program waits for 2 seconds and then resets the angle
     *              of the ball to zero, sends the ball in the opposite
     *              direction of who scored, and also reverts the goals'
     *              reset booleans. 
     */
    public IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        if(playerOneGoal.reset)
        {
            angle = 0;
            speed = 300f;
            playerOneGoal.reset = false;
        }
        else if (playerTwoGoal.reset)
        {
            angle = 0;
            speed = -300f;
            playerTwoGoal.reset = false;
        }
        ballBody.velocity = new Vector3(speed, angle, 0f);
    }

    /* OnCollisiion
     * Description: Bounces the ball off a surface. 
     * 
     * @param: Collision col
     * @return: void
     */
    private void OnCollisionEnter(Collision col)
    {
        bounceFromCollider(col);
    }

    /* bounceFromCollider
     * Description: This method handles the ball bouncing off the paddles as well as 
     *              bouncing off the surfaces on the court. First the location of the 
     *              ball and the collided object are retrieved. If the ball bounces off
     *              a paddle, then the trajectory of the ball is calculated by judging 
     *              where the ball bounced off of the paddle (top middle or bottom). 
     *              Otherwise, the ball keeps its x velocity and the y velocity is reversed. 
     *              The ball's speed is increased  and angle adjusted with each collision by 
     *              using the IncrementAndMove Method. 
     *         
     * @param: Collision c
     * @return: void
     */
    void bounceFromCollider(Collision c)
    {
        Vector3 ballPosition = ballBody.transform.position;
        Vector3 colPosition = c.gameObject.transform.position;

        float colHeight = c.collider.bounds.size.y;
        float x;
        float y;

        if(c.collider == playerOnePaddle || c.collider == playerTwoPaddle)
        {
            x = -1;
            y = (ballPosition.y - colPosition.y) / colHeight;
        }
        else
        {
            x = 1;
            y = angle / 400 * -1;
        }

        incrementAndMove(x, y);
    }

    /* IncrementAndMove
     * Description: adds 35 m/s to the speed with each collision 
     *              and then multiplies the angle by 400 to give
     *              an appropriate y velocity to the vecotr. The
     *              new vector is then applied to the ball.
     *              
     * @param: float x, float y
     * @return: void
     */
    private void incrementAndMove(float x, float y)
    {

        if (speed < 0)
        {
            speed = (speed - 35) * x;
        }
        else
        {
            speed = (speed + 35) * x;
        }

        float trueSpeed = Mathf.Abs(speed);

        if (trueSpeed > 700 )
        {
            speed = 685 * (speed/trueSpeed);  // extracts the sign from speed
        }

        angle = y * 400;
        ballBody.velocity = new Vector3(speed, angle, 0f);
    }
}
