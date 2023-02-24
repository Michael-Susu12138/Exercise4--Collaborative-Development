using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
    public void PlayGame(){
        SceneManager.LoadScene("level1");
    }
    public void ManualGame(){
        SceneManager.LoadScene("manualScene");
    }
    public void OptionGame(){
        SceneManager.LoadScene("Options");
    }
    public void GameOver(){
        
    }
    public void ReturnHome(){
        SceneManager.LoadScene("StartPage");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
