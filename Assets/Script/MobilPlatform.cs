using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilPlatform : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private Transform _startPoint;
    
    [SerializeField]
    private Transform _endPoint;

    [SerializeField]
    private float _timeToReach = 5f;

    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private float _distanceToActivate;

    #endregion

    #region Unity Lyfecycle
    void Start()
    {
        transform.position = _startPoint.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, _playerTransform.position) < _distanceToActivate)
        {
            if(_isForward)
            {
                _timerMovement += Time.deltaTime;
                if (_timerMovement >= _timeToReach)
                {
                    _isForward = false;
                }
            }
            else
            {
                _timerMovement -= Time.deltaTime;
                if (_timerMovement <= 0f)
                {
                    _isForward = true;
                }
            }
            Vector3 newPosition = Vector3.Lerp(_startPoint.position, _endPoint.position, _timerMovement / _timeToReach);
            transform.position = newPosition;
        }    
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    private float _timerMovement = 0f;
    private bool _isForward = true;
    #endregion
}
