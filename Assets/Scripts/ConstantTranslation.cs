using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantTranslation : MonoBehaviour
{

    [SerializeField] private Vector2 _translation;

    private void Update()
    {
        if (GameManager.Instance.State != GameState.InGame)
            return;

        transform.Translate(_translation * Time.deltaTime);
    }
    
}
