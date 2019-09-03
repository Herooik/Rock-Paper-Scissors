using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DefinitelyChoice : MonoBehaviour
{
    [SerializeField] private GameObject _player1, _player2;
    [SerializeField] private GameObject _definitelyChoosePlayer1, _definitelyChoosePlayer2;
    [SerializeField] private GameObject _objectButtons;

    [SerializeField] private InputController _inputController;
    [SerializeField] private GameplayController _gameplayController;
    
    private bool _isChoose = false;
    
    
    public void YesPlayer1()
    {
        _definitelyChoosePlayer1.SetActive(false);
        _definitelyChoosePlayer2.SetActive(false);
        _player1.SetActive(false);
        _player2.SetActive(true);
        
        GameChoices selectedChoice = GameChoices.NONE;
        
        switch (_inputController._choiceName)
        {
            case "Rock":
                selectedChoice = GameChoices.ROCK;
                break;

            case "Paper":
                selectedChoice = GameChoices.PAPER;
                break;

            case "Scissors":
                selectedChoice = GameChoices.SCISSORS;
                break;
        }
        
        _gameplayController.SetChoicesPlayer1(selectedChoice);
       
    }
    
    public void NoPlayer1()
    {
        GameObject _object = GameObject.FindGameObjectWithTag("Object");
        _definitelyChoosePlayer1.SetActive(false);
        _objectButtons.SetActive(true);
        Destroy(_object);
    }
    
    public void YesPlayer2()
    {
        _isChoose = true;
        _definitelyChoosePlayer2.SetActive(false);
        _player1.SetActive(true);
        _player2.SetActive(true);
        
        GameChoices selectedChoice = GameChoices.NONE;

        switch (_inputController._choiceName)
        {
            case "Rock":
                selectedChoice = GameChoices.ROCK;
                break;

            case "Paper":
                selectedChoice = GameChoices.PAPER;
                break;

            case "Scissors":
                selectedChoice = GameChoices.SCISSORS;
                break;
        }

        if (_isChoose)
        {
            _gameplayController.SetChoicesPlayer2(selectedChoice);
        }
        
       
    }

    
    public void NoPlayer2()
    {
        _isChoose = false;
        GameObject _object = GameObject.FindGameObjectWithTag("Object");
        _definitelyChoosePlayer2.SetActive(false);
        _objectButtons.SetActive(true);
        Destroy(_object);
    }
}
