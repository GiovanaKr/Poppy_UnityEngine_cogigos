using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private int total;

    [HideInInspector]
    public int count;
    [HideInInspector]
    public bool death;

    [SerializeField]
    private Text txPoint;
    [SerializeField]
    private Button replay;
    [SerializeField]
    private Button next;

    private void Awake(){
        total = GameObject.FindGameObjectsWithTag("Player").Length;
        txPoint.text = total.ToString();
        replay.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
    }

    private void Update(){
        Win();
        txPoint.text = count.ToString();

        if(Input.GetKeyDown("r")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(Input.GetKeyDown("escape")){
            SceneManager.LoadScene("StartMenu");
        }
        if(death){
            replay.gameObject.SetActive(true);
        }
    }

    private void Win(){
        if(count >= total){
            next.gameObject.SetActive(true);
            replay.gameObject.SetActive(true);
        }
    }

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Next(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
