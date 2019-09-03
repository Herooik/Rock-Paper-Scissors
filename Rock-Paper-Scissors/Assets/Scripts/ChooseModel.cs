using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseModel : MonoBehaviour
{
    [SerializeField] private GameObject _definitelyChoose;
    [SerializeField] private GameObject _objectButtons;

    public GameObject _object;
    
    public void AddObject()
    {
        _object.SetActive(true);

        _definitelyChoose.SetActive(true);
        _objectButtons.SetActive(false);
    }
}
