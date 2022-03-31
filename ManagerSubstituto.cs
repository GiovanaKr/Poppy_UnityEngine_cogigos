using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSubstituto : MonoBehaviour
{
    public bool death;
    public int count;

    public void MenuClick(){
        SceneManager.LoadScene("StartMenu");
    }
}
