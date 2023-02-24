using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleActivation : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private float _distanceToActivate;
    [SerializeField]
    private Transform _chandelierTransform;

    #endregion

    #region Unity Lyfecycle
    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        
    }
    void Start()
    {
    }

    void Update()
    {
        ParticleSystem.EmissionModule e = _particleSystem.emission;

        if (Vector2.Distance(_chandelierTransform.position, _playerTransform.position) < _distanceToActivate)
        {
            e.enabled = true;
        }
        else
        {
            e.enabled = false;
        }
    }
   
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    private ParticleSystem _particleSystem;

    #endregion
}
