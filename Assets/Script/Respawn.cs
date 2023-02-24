using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private Transform _respawnPoint;

    #endregion

    #region Unity Lyfecycle
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            collider.gameObject.transform.position = _respawnPoint.position;
        }
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    #endregion
}
