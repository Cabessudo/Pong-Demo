using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlesBase : MonoBehaviour
{
    public SpriteRenderer paddleSprite;
    public Vector2 defaultPos;
    public Vector2 limits = new Vector2(-4.5f, 4.5f);
    public Transform paddleDir;
    public float speed;

    void Update()
    {
        Movement();
    }

    public virtual void Movement()
    {}

    public void ResetPaddles()
    {
        transform.position = defaultPos;
    }
}
