using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI winnerText;

    void Start()
    {
        var winner = PlayerPrefs.GetString(SaveController.Instance.saveWinnerKey);
        if(winner != "")
            winnerText.text = "Last Winner " + winner;
        else 
            winner = "";
    }

}
