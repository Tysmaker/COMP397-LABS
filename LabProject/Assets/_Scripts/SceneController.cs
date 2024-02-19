using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : PersistentSingleton<SceneController>
{

    private static SceneController _instance = null;
    
    public void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ChangeSceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
