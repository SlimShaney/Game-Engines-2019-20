using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("BasicMenuScene");
    }
}
