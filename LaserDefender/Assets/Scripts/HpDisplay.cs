using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpDisplay : MonoBehaviour
{
    [SerializeField] Text hpValue;
    GameSession gameSession;
    void Start()
    {
        hpValue = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        hpValue.text = gameSession.GetPlayerHp().ToString();
    }
}
