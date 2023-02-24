using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PickUp : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private IntVariable _beerCollected;
    [SerializeField]
    private int _score = 1;
    [SerializeField]
    private Light2D _light;

    #endregion

    #region Unity Lyfecycle
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _beerCollected.m_value += _score;
            _light.enabled = false;
            Destroy(gameObject);
        }
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    #endregion
}
