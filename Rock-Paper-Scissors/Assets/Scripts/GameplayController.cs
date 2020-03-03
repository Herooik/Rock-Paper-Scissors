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
   private GameChoices _playerOneChoice = GameChoices.NONE, _playerTwoChoice = GameChoices.NONE;

   [SerializeField] private Text _playerWonText, _drawText, _playerOneScoreText, _playerTwoScoreText;
   
   [SerializeField] private GameObject _restartGameButton, _backToMenuButton, _quitButton;
   
   [HideInInspector] public int _playerOneScore, _playerTwoScore;

   private void Start()
   {
      ScoreUpdateAtStart();
   }

   private void ScoreUpdateAtStart()
   {
      _playerOneScore = PlayerPrefs.GetInt("PlayerOneScore");
      _playerTwoScore = PlayerPrefs.GetInt("PlayerTwoScore");
      _playerOneScoreText.text = _playerOneScore.ToString();
      _playerTwoScoreText.text = _playerTwoScore.ToString();
   }

   private void Update()
   {
      MenuInGame();
   }

   public void SetChoicePlayerOne(GameChoices gameChoices)
   {
      SetChoice(gameChoices, ref _playerOneChoice);
   }

   public void SetChoicePlayerTwo(GameChoices gameChoices)
   {
      SetChoice(gameChoices, ref _playerTwoChoice);
      
      CheckForWin();
   }
   
   private void SetChoice(GameChoices gameChoices,ref GameChoices playerChoice)
   {
      switch (gameChoices)
      {
         case GameChoices.ROCK:
            playerChoice = GameChoices.ROCK;
            break;

         case GameChoices.PAPER:
            playerChoice = GameChoices.PAPER;
            break;

         case GameChoices.SCISSORS:
            playerChoice = GameChoices.SCISSORS;
            break;
      }
   }

   private void CheckForWin()
   {
      if (_playerOneChoice == _playerTwoChoice)
      {
         StartCoroutine(ShowResultTextCo(_drawText, "DRAW"));
         
         ActivateEndRoundButtons();
      }

      if (_playerOneChoice == GameChoices.ROCK && _playerTwoChoice == GameChoices.SCISSORS)
      {
         EndRoundUpdate(ref _playerOneScore, _playerOneScoreText, "PLAYER 1 WON");
      }
      
      if (_playerOneChoice == GameChoices.SCISSORS && _playerTwoChoice == GameChoices.PAPER)
      {
         EndRoundUpdate(ref _playerOneScore, _playerOneScoreText, "PLAYER 1 WON");
      }
      
      if (_playerOneChoice == GameChoices.PAPER && _playerTwoChoice == GameChoices.ROCK)
      {
         EndRoundUpdate(ref _playerOneScore, _playerOneScoreText, "PLAYER 1 WON");
      }
      
      if (_playerOneChoice == GameChoices.ROCK && _playerTwoChoice == GameChoices.PAPER)
      {
         EndRoundUpdate(ref _playerTwoScore, _playerTwoScoreText, "PLAYER 2 WON");
      }
      
      if (_playerOneChoice == GameChoices.PAPER && _playerTwoChoice == GameChoices.SCISSORS)
      {
         EndRoundUpdate(ref _playerTwoScore, _playerTwoScoreText, "PLAYER 2 WON");
      }
      
      if (_playerOneChoice == GameChoices.SCISSORS && _playerTwoChoice == GameChoices.ROCK)
      {
         EndRoundUpdate(ref _playerTwoScore, _playerTwoScoreText, "PLAYER 2 WON");
      }
   }

   private void EndRoundUpdate(ref int playerScore, Text playerScoreText, string whoWon)
   {
      StartCoroutine(ShowResultTextCo(_playerWonText, whoWon));
      
      playerScore += 1;
      playerScoreText.text = playerScore.ToString();

      ActivateEndRoundButtons();
   }

   IEnumerator ShowResultTextCo(Text resultText, string whoWon)
   {
      resultText.text = whoWon;
      yield return new WaitForSeconds(.2f);
      resultText.gameObject.SetActive(true);
   }

   private void ActivateEndRoundButtons()
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
