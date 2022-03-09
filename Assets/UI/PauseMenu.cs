using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject DeathMenu;
    public GameObject pauseMenuUI;
    [SerializeField] private Score _score;
    [SerializeField] private GameObject playerMain;
    public Player player;
    void Update()
  
    {

        if (pauseMenuUI.gameObject.activeSelf || DeathMenu.gameObject.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    public void Pause()
    {
       pauseMenuUI.SetActive(true);
      Player.inAir = true; //выкл..
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Player.inAir = false; //вкл.
    }
    
    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        _score.ScorePause();
        Player.inAir = false;
        Time.timeScale = 1f;
        Player.health = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
