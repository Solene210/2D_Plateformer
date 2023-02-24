using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region Expose

    //[SerializeField]
    //private AudioSource _ambianceSound;
    //[SerializeField]
    //private Slider _maxVolumeSlider;
    //[SerializeField]
    //private Slider _musicVolumeSlider;

    //#endregion

    //#region Unity Life Cycle
    //private void Start()
    //{
    //    _ambianceSound.Play();
    //}
    //#endregion

    //#region Methods
    //public void MusicVol()
    //{
    //    _ambianceSound.volume= _maxVolumeSlider.value + _musicVolumeSlider.value;
    //}
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Private & Protected

    #endregion
}
