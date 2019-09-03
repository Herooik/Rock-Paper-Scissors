using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
   
   [SerializeField] private Text _gameEndingText;

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

   void CheckForWin()
   {
      if (_player1choice == _player2choice)
      {
         _gameEndingText.text = "DRAW";
         StartCoroutine(DisplayEndGameText());
      }

      if (_player1choice == GameChoices.ROCK && _player2choice == GameChoices.SCISSORS)
      {
         _gameEndingText.text = "PLAYER 1 WON";
         StartCoroutine(DisplayEndGameText());
      }
      if (_player1choice == GameChoices.SCISSORS && _player2choice == GameChoices.PAPER)
      {
         _gameEndingText.text = "PLAYER 1 WON";
         StartCoroutine(DisplayEndGameText());
      }
      if (_player1choice == GameChoices.PAPER && _player2choice == GameChoices.ROCK)
      {
         _gameEndingText.text = "PLAYER 1 WON";
         StartCoroutine(DisplayEndGameText());
      }
      
      if (_player2choice == GameChoices.ROCK && _player1choice == GameChoices.SCISSORS)
      {
         _gameEndingText.text = "PLAYER 2 WON";
         StartCoroutine(DisplayEndGameText());
      }
      if (_player2choice == GameChoices.SCISSORS && _player1choice == GameChoices.PAPER)
      {
         _gameEndingText.text = "PLAYER 2 WON";
         StartCoroutine(DisplayEndGameText());
      }
      if (_player2choice == GameChoices.PAPER && _player1choice == GameChoices.ROCK)
      {
         _gameEndingText.text = "PLAYER 2 WON";
         StartCoroutine(DisplayEndGameText());
      }
   }

   IEnumerator DisplayEndGameText()
   {
      yield return new WaitForSeconds(.2f);
      _gameEndingText.gameObject.SetActive(true);
   }
   
   
}
