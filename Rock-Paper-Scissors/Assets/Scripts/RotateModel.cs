using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
    [SerializeField] private float _rotSpeed = 5f;

    private void Update()
    {
        AutoRotateModel();
    }

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * _rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * _rotSpeed * Mathf.Deg2Rad;
        
        transform.RotateAround(Vector3.up,  - rotX);
        transform.RotateAround(Vector3.right, rotY);
    }

    private void AutoRotateModel()
    {
        transform.Rotate(Vector3.forward * 5f * Time.deltaTime);
        transform.Rotate(Vector3.up * 5f * Time.deltaTime);
    }
}
