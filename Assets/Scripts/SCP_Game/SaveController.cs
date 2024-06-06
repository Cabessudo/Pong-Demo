using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public Color playerColor = Color.white;
    public Color enemyColor = Color.white;

    public string playerName;
    public string enemyName;

    public string saveWinnerKey = "Winner Key";

    private static SaveController _instance;
    public static SaveController Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<SaveController>();

                if(_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }
    
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? playerName : enemyName;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(saveWinnerKey, winner);
    }

    public string GetWinner()
    {
        return PlayerPrefs.GetString(saveWinnerKey);
    }
    
    public void Reset()
    {
        playerColor = Color.white;
        enemyColor = Color.white;
        playerName = "";
        enemyName = "";
    }

    public void ClearSave()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerPrefs.DeleteAll();
    }
}