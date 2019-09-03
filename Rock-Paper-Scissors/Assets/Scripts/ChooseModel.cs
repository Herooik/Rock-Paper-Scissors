using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseModel : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _definitelyChoose;
    [SerializeField] private GameObject _objectButtons;
    
    public void AddObject()
    {
        GameObject _myObject = Instantiate(_object);
        _myObject.transform.parent = _player.transform;

        _definitelyChoose.SetActive(true);
        _objectButtons.SetActive(false);
    }
}
