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

        StartCoroutine(DelaySceneLoadCo(1));
    }

   

    public void RestartGame()
    {
        PlayerPrefs.SetInt("Player1Score", _gameplayController._player1score);
        PlayerPrefs.SetInt("Player2Score", _gameplayController._player2score);
        
        StartCoroutine(DelaySceneLoadCo(1));
        
    }

    public void BackToMenu()
    {
        StartCoroutine(DelaySceneLoadCo(0));
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator DelaySceneLoadCo(int numOfScene)
    {
        yield return new WaitForSeconds(.2f);        // allow to play sound on button click
        SceneManager.LoadScene(numOfScene);
    }
    
}
