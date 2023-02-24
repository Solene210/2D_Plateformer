using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private IntVariable _beerCollected;
    [SerializeField]
    private GameObject _pauseScreen;

    #endregion

    #region Unity Lyfecycle
    void Start()
    {
        _beerCollected.m_value = 0;
        Time.timeScale = 1;
    }

    void Update()
    {
        Pause();
    }

    #endregion

    #region Methods

    private void Pause()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            _pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Play()
    {
        Time.timeScale = 1;
        _pauseScreen.SetActive(false);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenue()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Private & Protected

    #endregion
}
