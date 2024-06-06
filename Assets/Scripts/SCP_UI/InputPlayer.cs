using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public bool isPlayer = true;
    public TMPro.TMP_InputField inputName;

    // Start is called before the first frame update
    void Start()
    {
        inputName.onValueChanged.AddListener(SetName);
    }

    public void SetName(string name)
    {
        if(isPlayer)
            SaveController.Instance.playerName = name;
        else
            SaveController.Instance.enemyName = name;
    }
}
