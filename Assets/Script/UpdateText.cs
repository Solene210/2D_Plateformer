using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private IntVariable _beersCollected;

    #endregion

    #region Unity Lyfecycle
    private void Awake()
    {
        _label = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        _label.text = _beersCollected.m_value.ToString();
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    private TextMeshProUGUI _label;

    #endregion
}
