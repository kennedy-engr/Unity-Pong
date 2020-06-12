﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* playerOneGoal
 * Description: This class provides the functionality for when player 
 *              ONE scores. The scoring text of the game scene is updated
 *              here as well as the count for when the game will be over.
 *              Whoever reaches 6 points first wins. Also controls the reset
 *              varaible used in Ball class. 
 */
public class playerOneGoal : MonoBehaviour
{
    /* Public Variables*/
    public Text playerOneText;
    public static bool reset = false;
    public static bool winner = false;

    /* Private Variables */
    private int score;

    /* Start
     * Description: Initializes score to 0 and dispalys 
     *              the first score value at the start of 
     *              the game. 
     */
    void Start()
    {
        score = 0;
        playerOneText.text = "Player One: " + score;
    }

    /* Update
     * Description: Checks to see when the score of player one 
     *              reaches 6 (A single set of Tennis!). Handles the   
     *              transition to scene 2 (GameOver).
     */
    void Update()
    {
        if(score == 6)
        {
            winner = true;
            SceneManager.LoadScene(2);
        }
    }

    /* OnTriggerEnter
     * Description: When the collider for player one is triggered 
     *              (set as 'trigger' in inspector), the score is
     *              incremented, the text is updated, and the ball 
     *              is reset. 
     *              
     * @param: Collider col
     * @return void
     */
    private void OnTriggerEnter(Collider col)
    {
        score++;
        playerOneText.text = "Player One: " + score;
        reset = true;
    }

}
