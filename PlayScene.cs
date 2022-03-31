using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScene : MonoBehaviour
{
    public void StartButton(){
        SceneManager.LoadScene("level1");
    }

    public void LevelsButton(){
        Debug.Log("levels");
    }

    public void ExitButton(){
        Debug.Log("quit");
        Application.Quit();
    }
}
