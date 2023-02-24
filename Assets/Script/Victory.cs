using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Victory : MonoBehaviour
{
    #region Expose
    [SerializeField]
    private GameObject _victoryUI;
    //[SerializeField]
    //private IntVariable _beercount;
    //[SerializeField]
    //private TextMeshProUGUI _textBeerCount;

    #endregion

    #region Unity Lyfecycle
    private void Awake()
    {
       // _textBeerCount = GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            VictoryLevel();
        }
    }
    #endregion

    #region Methods

    private void VictoryLevel()
    {

        _victoryUI.SetActive(true);
        //_textBeerCount.text =  _beercount.m_value.ToString();
        //Debug.Log("Victoire");
    }

    #endregion

    #region Private & Protected

    #endregion
}
