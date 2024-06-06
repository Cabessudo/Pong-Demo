using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public BallController ball;

    public List<PaddlesBase> paddles;
    public List<PointCounter> pointCounters;
    public List<ParticleSystem> PS_win;

    [Header("Texts")]
    public GameObject winText;
    public GameObject loseText;
    public GameObject endButtons;

    [Header("Names")]
    public List<TextMeshProUGUI> playerName;
    public List<TextMeshProUGUI> enemyName;
 
    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetGame();   
        SetNames();
    }

    void ResetGame()
    {
        ball.ResetBall();
        
        foreach(var p in paddles)
            p.ResetPaddles();
    }

    public void SideScore(SideType currSide)
    {
        var p = pointCounters.Find(i => i.side == currSide);
        p?.Score();
        if(!p.endGame) ResetGame();
    }

    [NaughtyAttributes.Button]
    public void Win()
    {
        PS_win.ForEach(i => i.Play());
        winText.SetActive(true);
        endButtons.SetActive(true);
    }

    public void Lose()
    {
        loseText.SetActive(true);
        endButtons.SetActive(true);
    }

    public void Restart()
    {
        winText.SetActive(false);
        loseText.SetActive(false);
        endButtons.SetActive(false);
        ResetGame();

        foreach(var p in pointCounters)
            p.Reset();
    }

    void SetNames()
    {
        if(SaveController.Instance.playerName != "")
            playerName.ForEach(i => i.SetText(SaveController.Instance.playerName));

        if(SaveController.Instance.enemyName != "")
        {
            enemyName.ForEach(i => i.SetText(SaveController.Instance.enemyName));
            enemyName[1].text += " Wins";
        }

    }
}