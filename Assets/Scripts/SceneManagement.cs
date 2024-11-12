using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Call this function when the player presses the Start button
    public void StartGame()
    {
        // Load the Loading Screen scene
        SceneManager.LoadScene("LoadingScreen");
    }
}
