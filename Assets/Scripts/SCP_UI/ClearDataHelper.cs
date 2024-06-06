using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDataHelper : MonoBehaviour
{
    public void ClearData()
    {
        SaveController.Instance.ClearSave();
    }
}
