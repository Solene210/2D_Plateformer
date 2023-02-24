using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    #region Expose
    public AudioMixer _mixer;
    #endregion

    #region Unity Lyfecycle
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    #region Methods
    public void SetLevel(float sliderValue)
    {
        _mixer.SetFloat("CaveMasterVol", Mathf.Log10(sliderValue) * 20);
    }
    #endregion

    #region Private & Protected

    #endregion
}
