using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{
    public int level;

    public void Load()
    {
        SceneManager.LoadScene(level);
    }
}
