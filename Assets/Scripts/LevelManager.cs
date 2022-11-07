using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{ 
    ScoreKeeper scoreKeeper;

    public void LoadMainMenu()
    {
     SceneManager.LoadScene("Main Menu");
    }
   public void LoadGame()
   {
     scoreKeeper = FindObjectOfType<ScoreKeeper>();
     scoreKeeper.ResetScore();
     SceneManager.LoadScene("Core Game");
   }
   public void GameOver()
   {
     StartCoroutine (LoadEndScreen());
   }

   IEnumerator LoadEndScreen()
   {
     yield return new WaitForSecondsRealtime(2);
     SceneManager.LoadScene("End Screen");
   }
   public void QuitGame()
   {
     Debug.Log("Quitting");
     Application.Quit();
   }
}
