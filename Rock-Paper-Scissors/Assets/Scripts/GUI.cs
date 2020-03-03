using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    [SerializeField] private GameplayController _gameplayController;
    
    public void StartGame()
    {
        PlayerPrefs.SetInt("PlayerOneScore", 0);
        PlayerPrefs.SetInt("PlayerTwoScore", 0);

        StartCoroutine(DelaySceneLoadCo(1));
    }

   

    public void RestartGame()
    {
       // Debug.Log(_gameplayController._playerOneScore);
        PlayerPrefs.SetInt("PlayerOneScore", _gameplayController._playerOneScore);
        PlayerPrefs.SetInt("PlayerTwoScore", _gameplayController._playerTwoScore);
        
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
