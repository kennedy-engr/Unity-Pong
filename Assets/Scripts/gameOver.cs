using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Game Over Manager
 * Description: watches the boolean winner in the playerGoal classes
 *              and if trigered then changes the text of Scene 3 
 *              to describe who has won. Also provides an option to
 *              return to Main Menu.
 */
public class gameOver : MonoBehaviour
{
    public Text finalText;

    void Start()
    {
        changeText();
    }

    /* changeText
     * Description: Changes winnerText of the Canvas in scene 3
     *              to describe who has won.
     */
    private void changeText()
    {
        if (playerOneGoal.winner)
        {
            finalText.text = "Player One Wins!";
        }
        else if (playerTwoGoal.winner)
        {
            finalText.text = "Player Two Wins!";
        }
    }

    /* onButtonPress()
     * Description: Connected to the large green button
     * of Scene 3 ( Game Over ), Loads the Main Menu Scene
     */
    public void onButtonPress()
    {
        SceneManager.LoadScene(0);
    }
}
