using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePref : MonoBehaviour
{
    #region Expose

    #endregion

    #region Unity Lyfecycle
    private void Awake()
    {
        _keyName = gameObject.name;

        string prefValue = PlayerPrefs.GetString(_keyName);
        if (prefValue != "False")
        {
            GetComponent<Toggle>().isOn = true;
        }
        else
        {
            GetComponent<Toggle>().isOn = false;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    #region Methods

    public void TogglePrefValue(bool isOn)
    {
        PlayerPrefs.SetString(_keyName, isOn.ToString());
    }

    #endregion

    #region Private & Protected

    private string _keyName;
    
    #endregion
}
