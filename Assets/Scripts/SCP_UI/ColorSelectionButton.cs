using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    public Button buttonColor;
    public Image paddleReference;
    public bool isPlayer = true;

    void Start()
    {
        buttonColor = GetComponent<Button>();
    }

    public void OnClickEnter()
    {
        paddleReference.color = buttonColor.colors.normalColor;

        if(isPlayer)
            SaveController.Instance.playerColor = paddleReference.color;
        else
            SaveController.Instance.enemyColor = paddleReference.color;
    }
}
