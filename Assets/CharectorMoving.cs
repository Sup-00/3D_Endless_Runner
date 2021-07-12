using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum Directions
{
    Left,
    Center,
    Right
};

[RequireComponent( typeof(Rigidbody))]
public class CharectorMoving : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _distanceBetweenLine;
    
    private Directions _currentDirection;

    private void Start()
    {
        _currentDirection = Directions.Center;
    }

    private void Update()
    {
        transform.position += Vector3.forward * _runSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_currentDirection == Directions.Center)
            {
                transform.position = new Vector3(-2.5f,transform.position.y,transform.position.z);
                _currentDirection = Directions.Left;
            }
            else if (_currentDirection == Directions.Right)
            {
                transform.position = new Vector3(0f,transform.position.y,transform.position.z);
                _currentDirection = Directions.Center;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_currentDirection == Directions.Center)
            {
                transform.position = new Vector3(2.5f,transform.position.y,transform.position.z);
                _currentDirection = Directions.Right;
            }
            else if (_currentDirection == Directions.Left)
            {
                transform.position = new Vector3(0f,transform.position.y,transform.position.z);
                _currentDirection = Directions.Center;
            }
        }
    }
}
