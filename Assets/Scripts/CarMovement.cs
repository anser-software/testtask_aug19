using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    
    [SerializeField] private float _leftX, _rightX;
    
    [SerializeField] private float _switchSpeed;
    
    private Lane _currentLane = Lane.Right;
    
    private Vector3 _targetPosition;
    
    private void Start()
    {
        SwitchLanes();
    }
    
    private void Update()
    {
        if (GameManager.Instance.State != GameState.InGame)
            return;
        
        if(Input.GetMouseButtonDown(0) && Input.mousePosition.y / Screen.height < 0.8F)
        {
            SwitchLanes();
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _switchSpeed * Time.deltaTime);
    }

    private void SwitchLanes()
    {
        if (_currentLane == Lane.Left)
        {
            _currentLane = Lane.Right;
            _targetPosition = new Vector3(_rightX, transform.position.y);
        }
        else
        {
            _currentLane = Lane.Left;
            _targetPosition = new Vector3(_leftX, transform.position.y);
        }
    }
    
    private enum Lane
    {
        Left,
        Right
    }
    
}
