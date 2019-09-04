using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    [SerializeField] private GameplayController _gameplayController;
    
    public void StartGame()
    {
        PlayerPrefs.SetInt("Player1Score", 0);
        PlayerPrefs.SetInt("Player2Score", 0);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   

    public void RestartGame()
    {
        PlayerPrefs.SetInt("Player1Score", _gameplayController._player1score);
        PlayerPrefs.SetInt("Player2Score", _gameplayController._player2score);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
}
