using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mainGame;
    [SerializeField] public TextMeshProUGUI deathMenu;
    private int current;
    private bool pause;


    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            current++;
            mainGame.text = current.ToString();

            if (pause == true)
                break;
        }
    }

    public void ScorePause()
    {
        var best = PlayerPrefs.GetInt("BestScore12", 0);
        if (best < current)
        {
            best = current;
            PlayerPrefs.SetInt("BestScore123", best);
            deathMenu.text = best.ToString();
        }

        deathMenu.text = best.ToString();
        pause = true;
        
    }
}


