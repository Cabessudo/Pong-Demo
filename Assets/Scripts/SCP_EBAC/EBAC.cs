using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBAC : MonoBehaviour
{
    //Esse é para SaveManager
    private static EBAC _ebac;
    public static EBAC Ebac
    {
        get
        {
            if(_ebac == null)
            {
                _ebac = FindObjectOfType<EBAC>();
                
                if(_ebac == null)
                {
                    GameObject newObject = new GameObject(nameof(EBAC));
                    _ebac = newObject.AddComponent<EBAC>();
                }

            }
            return _ebac;
        }
    }






    //Forma mais facil de pegar algum componente
    public string two;
    public string one;
    public string GetStrind(bool b)
    {
        //se b for verdadeiro retorna 1 se não 2 
        return b ? one : two; 
    }
}
