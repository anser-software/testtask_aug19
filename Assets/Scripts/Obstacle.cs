using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    [SerializeField] private float _clearanceY = -6F;

    private bool _cleared = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
    
    private void Update()
    {
        if (_cleared)
            return;

        if (transform.position.y > _clearanceY) 
            return;
        
        _cleared = true;
        ScoreManager.Instance.AddScore(1);
    }
    
}
