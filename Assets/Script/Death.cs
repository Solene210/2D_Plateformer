using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private GameObject _gameOverUI;
    [SerializeField]
    private Animator _deathAnimation;

    #endregion

    #region Unity Lyfecycle
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {

            DeathPerso();
        }
    }
    #endregion

    #region Methods
    private void DeathPerso()
    {
        
        _gameOverUI.SetActive(true);
        _deathAnimation.Play("Death");
        //Debug.Log("GameOver");
    }
    #endregion

    #region Private & Protected

    #endregion
}
