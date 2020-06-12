using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*moveOne (Movement for Player One)
 * Description: This class contains the variables and functions
 *              that are associated with the speed and inputs for the player 
 *              paddle on the left hand side of the game. 
*/
public class moveOne : MonoBehaviour
{
    /* Public Variables */
    public Rigidbody onePaddle; // Specified in Unity interface

    /* Private Variables */
    private float speed = 300f; // speed of paddle movement
    private bool oneUpPress;    // used for upwards input  check
    private bool oneDownPress;  // used for downward input check
    private Touch touch;

    /* Start
     * Description: Used for initializing the player one paddle 
     *              upon startup of the game.
     */
    void Start()
    {
        onePaddle = GetComponent<Rigidbody>();
    }

    /* Update
     * Description: Gets inputs on 'w' and 's' keys
     *              during active runtime of the game.
     */
    void Update()
    {
        // Desktop Controls
        oneUpPress = Input.GetKey(KeyCode.W);
        oneDownPress = Input.GetKey(KeyCode.S);

        // Touch controls (not finished)
        /*
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }
        */
       
        playerOneMove();
        
    }

    /* playerOneMove
     * Description: This method is called at a high frequency 
     *              to check which inputs are pressed and to 
     *              apply velocity vectors accordingly. Handles 
     *              no input or both 'w' and 's' input which resolves
     *              to0 0 velocity.
     */
    private void playerOneMove()
    {
        // Touch Controls (not finished)
        /*
        Vector2 touchLocation = touch.position;

        Debug.Log(touchLocation);

        if(touchLocation.y > 230)
        {
            oneUpPress = true;
        }
        else if (touchLocation.y < 230)
        {
            if(touchLocation.y == 0) { }
            else oneDownPress = true;
        }
        */
        
        // Desktop Controls
        if (oneUpPress)
        {
            onePaddle.velocity = new Vector3(0f, speed, 0f);
        }
        else if (oneDownPress)
        {
            onePaddle.velocity = new Vector3(0f, speed * -1, 0f);
        }
        else
        {
            onePaddle.velocity = new Vector3(0f, 0f, 0f);
        }
    }

}