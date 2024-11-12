using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public string mainLevelName = "Level";

    private void Start()
    {
        StartCoroutine(LoadMainLevelAsync());
    }

    IEnumerator LoadMainLevelAsync()
    {
       
        AsyncOperation operation = SceneManager.LoadSceneAsync(mainLevelName);
        operation.allowSceneActivation = false;  // Prevent automatic scene activation

        
        Debug.Log("Loading...");

      
        while (!operation.isDone)
        {

            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
