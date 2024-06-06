using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform t;

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = t.position - transform.position;
        transform.Translate(-lookDir * 1 * Time.deltaTime);
    }
}
