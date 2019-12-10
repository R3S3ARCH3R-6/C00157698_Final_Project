using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// The following script controls everything UI related, like the start and quit screens
/// </summary>
public class UI_Control : MonoBehaviour
{
    public Text FinalScore; //displays the final game score

    // Start is called before the first frame update
    void Start()
    {
        //enables the mouse cursor to appear to select items on screen
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (FinalScore)
        {
            FinalScore.text = "Final Score/Health: " + FoodCollector.playerHealth;
        }
    }

    /// <summary>
    /// Quits the game entirely. This script stops the program/game
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
 #endif
    }

    /// <summary>
    /// Goes to the FPS version of the game
    /// </summary>
    public void FPS_Start()
    {
        SceneManager.LoadScene("First-Person-Scene");
    }

    /// <summary>
    /// Goes to the third-person version of the game
    /// </summary>
    public void TPS_Start()
    {
        SceneManager.LoadScene("Third-Person-Scene");
    }

    /// <summary>
    /// Goes to the homescreen/first-scene of the game
    /// </summary>
    public void HomeStart()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
