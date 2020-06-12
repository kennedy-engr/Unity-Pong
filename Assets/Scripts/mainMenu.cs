/* Author: Kennedy Echeverry
 * Date 3/31/2020
 * Contact: email: kenech8@gmail.com
 *          phone: +1 (214)-802-5358
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/* MainMenu (MainMenu Manager)
 * Description: This class controls the MainMenu Scene by 
 *              monitoring the two buttons in the scene.
 *              Scene 0 = Main Menu
 *              Scene 1 = Game Scene
 *              Scene 2 = Game Over               
 */
public class mainMenu : MonoBehaviour
{
    /* Public Variables */ 
    public static bool twoPlayer;

    /* Start
     * Description: Initializes the twoPlayer boolean to 
     *              false. The default case is a one player 
     *              game. 
     */
    private void Start()
    {
        twoPlayer = false;
    }

    /* getTwoPlayer
    * Description: a simple "getter" for the 
    *              twoPlayer Boolean variable
    * @param n/a
    * @return twoPalyer
    */
    public bool getTwoPlayer()
    {
        return twoPlayer;
    }

    /* onOneButtonPress
     * Description: If the "One Player" button is pressed,
     *              then Scene 1 is loaded while the twoPlayer 
     *              bool remains false. 
     */
    public void onOneButtonPress()
    {
        SceneManager.LoadScene(1);
    }

    /* onTwoButtonPress
    * Description: If the "Two Player" button is pressed,
    *              then Scene 1 is loaded and the twoPlayer 
    *              bool is changed to true.
    */
    public void onTwoButtonPress()
    {
        twoPlayer = true;
        SceneManager.LoadScene(1);
    }


} // end class


