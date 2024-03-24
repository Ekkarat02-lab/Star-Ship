using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void credit()
   {
      SceneManager.LoadScene("credit");
   }
   
   public void HowToplay()
   {
      SceneManager.LoadScene("How To Play");
   }
   
   public void QuitGame()
   {
      Application.Quit();
   }
}
