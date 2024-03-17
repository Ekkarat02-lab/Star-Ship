using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScore : MonoBehaviour
{
    Text txt_score;
    public GameSystem gameSystem;
    void Start()
    {
        if(gameSystem == null){
            GameObject _gameSystem = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            gameSystem = _gameSystem.GetComponent<GameSystem>();
        }
        txt_score = GetComponent<Text>();
    }
    void Update()
    {
        txt_score.text = ""+gameSystem.score;
    }
}
