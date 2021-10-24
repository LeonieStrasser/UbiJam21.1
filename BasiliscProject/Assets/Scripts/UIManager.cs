using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }    
}

