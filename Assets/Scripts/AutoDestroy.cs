using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    
    [SerializeField] private float _timeToDestroy = 5F;

    private float _timer = 0F;

    private void Update()
    {
        if (GameManager.Instance.State != GameState.InGame)
            return;
        
        _timer += Time.deltaTime;
        
        if (_timer > _timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
