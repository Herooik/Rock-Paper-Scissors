using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DefinitelyChoice : MonoBehaviour
{
    [SerializeField] private GameObject _playerOne, _playerTwo;
    [SerializeField] private GameObject _definitelyChoosePlayerOne, _definitelyChoosePlayerTwo;
    [SerializeField] private GameObject _objectButtons;
    [SerializeField] private GameObject[] _objects;
    
    [SerializeField] private InputController _inputController;
    [SerializeField] private GameplayController _gameplayController;
    
    private bool _isChoose = false;


    public void YesPlayer1()
    {
        _definitelyChoosePlayerOne.SetActive(false);
        _definitelyChoosePlayerTwo.SetActive(false);
        _playerOne.SetActive(false);
        _playerTwo.SetActive(true);
        
        var selectedChoice = SelectedChoice();

        _gameplayController.SetChoicePlayerOne(selectedChoice);
       
    }
    
    public void YesPlayer2()
    {
        _isChoose = true;
        
        _definitelyChoosePlayerTwo.SetActive(false);
        _playerOne.SetActive(true);
        _playerTwo.SetActive(true);

        var selectedChoice = SelectedChoice();

        if (_isChoose)
        {
            _gameplayController.SetChoicePlayerTwo(selectedChoice);
        }
    }
    
    private GameChoices SelectedChoice()
    {
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

        return selectedChoice;
    }

    public void NoPlayer1()
    {
        _definitelyChoosePlayerOne.SetActive(false);
        
        for (int i = 0; i <= 2; i++)
        {
            _objects[i].SetActive(false);
        }

        _objectButtons.SetActive(true);
       
    }
    
    public void NoPlayer2()
    {
        _isChoose = false;
        _definitelyChoosePlayerTwo.SetActive(false);
        
        for (int i = 0; i <= 2; i++)
        {
            _objects[i].SetActive(false);
        }
        
        _objectButtons.SetActive(true);
    }
}
