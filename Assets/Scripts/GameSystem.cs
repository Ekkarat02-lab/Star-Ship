using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSystem : MonoBehaviour
{
    public int score = 0;
    public int hp = 5;
    public bool isGameOver = false;
    public bool isStartGame = false;
    public GameObject GameTitleScene,GameOverScene;
    public GameObject spawnPoint;
//Call Player Class
    Player player;
    void Start()
    {
        spawnPoint.SetActive(false);
        if(player == null){
            GameObject _player = GameObject.FindGameObjectWithTag("Player") as GameObject;
            player = _player.GetComponent<Player>();
        }
    }
// Update is called once per frame
    void Update()
    {
        if(isGameOver){
            spawnPoint.SetActive(false);
            GameOverScene.SetActive(true);
            GameTitleScene.SetActive(false);
        }
        if(isStartGame){
            spawnPoint.SetActive(true);
            GameOverScene.SetActive(false);
            GameTitleScene.SetActive(false);
        }
        if(hp<=0){
            hp = 0;
            isGameOver=true;
            isStartGame = false;
        }
    }
    public void ClickStartGame(){
        isGameOver = false;
        isStartGame = true;
    }
    public void resetGame(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }
    public void getEnemy(){
        hp = hp - 1;
    }
    public void getPoint(){
        score = score + 1;
    }
}