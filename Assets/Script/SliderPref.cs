using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPref : MonoBehaviour
{
    #region Expose

    #endregion

    #region Unity Lyfecycle
    private void Awake()
    {
        _keyName = gameObject.name;
        GetComponent<Slider>().value = PlayerPrefs.GetFloat(_keyName);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    #region Methods
    public void SliderPrefValue(float value)
    {
        PlayerPrefs.SetFloat(_keyName, value);
    }
    #endregion

    #region Private & Protected

    private string _keyName;
    #endregion
}
