using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum SideType
{
    Player,
    Enemy
}

public class PointCounter : MonoBehaviour
{
    public SideType side;
    public Animator scoreAnim;
    public TextMeshProUGUI pointText; 
    private string sideName;
    public int currPoint;
    public int winPoint = 5;
    public bool endGame;

    void Start()
    {
        SetName();
        pointText?.SetText("0");
    }

    public void Score()
    {
        currPoint++;
        pointText?.SetText(currPoint.ToString());
        scoreAnim.SetTrigger("Score");
        CheckWin();
    }

    public void Reset()
    {
        endGame = false;
        currPoint = 0;
        pointText?.SetText(currPoint.ToString());
    }

    void CheckWin()
    {
        if(currPoint >= winPoint)
        {
            endGame = true;

            if(side == SideType.Player)
            {
                GameManager.Instance.Win();
            }

            if(side == SideType.Enemy)
            {
                GameManager.Instance.Lose();
            }

            SaveController.Instance.SaveWinner(sideName);
        }
    }

    void SetName()
    {
        if(side == SideType.Player && SaveController.Instance.playerName != "")
            sideName = SaveController.Instance.playerName;

        if(side == SideType.Enemy && SaveController.Instance.enemyName != "")
            sideName = SaveController.Instance.enemyName;
    }
}
