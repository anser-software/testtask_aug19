using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatTilingAnim : MonoBehaviour
{

    [SerializeField] private Material _material;
    [SerializeField] private Vector2 _tilingChange;

    private void Update()
    {
        if (GameManager.Instance.State != GameState.InGame)
            return;
        
        _material.mainTextureOffset += _tilingChange * Time.deltaTime;
    }
}
