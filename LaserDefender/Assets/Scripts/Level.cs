using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [Header("Scene Names")]
    [SerializeField] string gameover;
    [SerializeField] string gamestart;
    [SerializeField] string gameplay;

    public void LoadGameOver(){
        SceneManager.LoadScene(gameover);
    }
    public void LoadGame(){
        SceneManager.LoadScene(gameplay);
    }
    public void LoadStartMenu(){
        SceneManager.LoadScene(gamestart);
    }
    public void QuitGame(){
        Application.Quit();
    }
}
