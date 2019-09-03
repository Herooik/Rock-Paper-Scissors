using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    public string _choiceName;
    
    public void GetChoicePlayer1()
    {
        _choiceName = EventSystem.current.currentSelectedGameObject.name;
    }

    public void GetChoicePlayer2()
    {
        _choiceName = EventSystem.current.currentSelectedGameObject.name;
    }
}
