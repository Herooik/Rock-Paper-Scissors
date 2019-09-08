using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseModel : MonoBehaviour
{
    [SerializeField] private GameObject _definitelyChoose;
    [SerializeField] private GameObject _objectButtons;
    [SerializeField] private GameObject _objectToSpawn;
    
    public void AddObject()
    {
        _objectToSpawn.SetActive(true);

        _definitelyChoose.SetActive(true);
        
        _objectButtons.SetActive(false);
    }
}
