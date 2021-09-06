using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    // Start is called before the first frame update
    void Awake(){
        SetUpSingleton();
    }

    private void SetUpSingleton(){
       if(FindObjectsOfType<GameSession>().Length > 1) {
           gameObject.SetActive(false);
           Destroy(gameObject);
       }else{
           DontDestroyOnLoad(gameObject);
       }
    }
    public int GetScore(){ return score; }

    public int GetPlayerHp(){ 
        if(FindObjectOfType<Player>()){
            return FindObjectOfType<Player>().GetHp();
        }else{
            return 0;
        }
    }

    public void AddToScore(int points){ score += points;}

    public void ResetScore(){ score = 0; }
}
