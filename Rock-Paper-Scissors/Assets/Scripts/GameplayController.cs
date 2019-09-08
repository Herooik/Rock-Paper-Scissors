using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameChoices
{
   NONE,
   ROCK,
   PAPER,
   SCISSORS
}

public class GameplayController : MonoBehaviour
{
   private GameChoices _player1choice = GameChoices.NONE, _player2choice = GameChoices.NONE;

   [SerializeField] private Text _playerWonText, _drawText, _player1scoreText, _player2scoreText;
   
   [SerializeField] private GameObject _restartGameButton, _backToMenuButton, _quitButton;
   
   [HideInInspector] public int _player1score, _player2score;

   private void Start()
   {
      _player1score = PlayerPrefs.GetInt("Player1Score");
      _player2score = PlayerPrefs.GetInt("Player2Score");
      _player1scoreText.text = _player1score.ToString();
      _player2scoreText.text = _player2score.ToString();
   }

   private void Update()
   {
      MenuInGame();
   }

   public void SetChoicesPlayer1(GameChoices gameChoices)
   {
      switch (gameChoices)
      {
         case GameChoices.ROCK:
            _player1choice = GameChoices.ROCK;
            break;
         
         case GameChoices.PAPER:
            _player1choice = GameChoices.PAPER;
            break;
         
         case GameChoices.SCISSORS:
            _player1choice = GameChoices.SCISSORS;
            break;
      }
   }
   
   public void SetChoicesPlayer2(GameChoices gameChoices)
   {
      switch (gameChoices)
      {
         case GameChoices.ROCK:
            _player2choice = GameChoices.ROCK;
            break;
         
         case GameChoices.PAPER:
            _player2choice = GameChoices.PAPER;
            break;
         
         case GameChoices.SCISSORS:
            _player2choice = GameChoices.SCISSORS;
            break;
      }

      CheckForWin();
   }

   private void CheckForWin()
   {
      if (_player1choice == _player2choice)
      {
         _drawText.text = "DRAW";
         StartCoroutine(DisplayDrawTextCo());
         ActivateEndGameButtons();
      }

      if (_player1choice == GameChoices.ROCK && _player2choice == GameChoices.SCISSORS)
      {
         _playerWonText.text = "PLAYER 1 WON";
         StartCoroutine(DisplayPlayerWonTextCo());
         
         _player1score += 1;
         _player1scoreText.text = _player1score.ToString();
         
         ActivateEndGameButtons();
      }
      if (_player1choice == GameChoices.SCISSORS && _player2choice == GameChoices.PAPER)
      {
         _playerWonText.text = "PLAYER 1 WON";
         StartCoroutine(DisplayPlayerWonTextCo());
         
         _player1score += 1;
         _player1scoreText.text = _player1score.ToString();
         
         ActivateEndGameButtons();
      }
      if (_player1choice == GameChoices.PAPER && _player2choice == GameChoices.ROCK)
      {
         _playerWonText.text = "PLAYER 1 WON";
         StartCoroutine(DisplayPlayerWonTextCo());
         
         _player1score += 1;
         _player1scoreText.text = _player1score.ToString();
         
         ActivateEndGameButtons();
      }
      
      if (_player2choice == GameChoices.ROCK && _player1choice == GameChoices.SCISSORS)
      {
         _playerWonText.text = "PLAYER 2 WON";
         StartCoroutine(DisplayPlayerWonTextCo());
         
         _player2score += 1;
         _player2scoreText.text = _player2score.ToString();
         
         ActivateEndGameButtons();
      }
      if (_player2choice == GameChoices.SCISSORS && _player1choice == GameChoices.PAPER)
      {
         _playerWonText.text = "PLAYER 2 WON";
         StartCoroutine(DisplayPlayerWonTextCo());
         
         _player2score += 1;
         _player2scoreText.text = _player2score.ToString();
         
         ActivateEndGameButtons();
      }
      if (_player2choice == GameChoices.PAPER && _player1choice == GameChoices.ROCK)
      {
         _playerWonText.text = "PLAYER 2 WON";
         StartCoroutine(DisplayPlayerWonTextCo());
         
         _player2score += 1;
         _player2scoreText.text = _player2score.ToString();
         
         ActivateEndGameButtons();
      }
   }

   IEnumerator DisplayPlayerWonTextCo()
   {
      yield return new WaitForSeconds(.2f);
      _playerWonText.gameObject.SetActive(true);
   }

   IEnumerator DisplayDrawTextCo()
   {
      yield return new WaitForSeconds(.2f);
      _drawText.gameObject.SetActive(true);
   }

   private void ActivateEndGameButtons()
   {
      _restartGameButton.SetActive(true);
      _backToMenuButton.SetActive(true);
      _quitButton.SetActive(true);
   }

   private void MenuInGame()
   {
      if (Input.GetKey(KeyCode.Escape))
      {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
      }
   }
   
   
}
