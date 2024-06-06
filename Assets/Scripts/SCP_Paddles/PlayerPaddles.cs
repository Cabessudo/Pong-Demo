using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddles : PaddlesBase
{
    void Start()
    {
        paddleSprite.color = SaveController.Instance.playerColor;
    }

    public override void Movement()
    {
        float inputY = Input.GetAxis("Vertical");

        Vector2 movePos = transform.position + Vector3.up * inputY * speed * Time.deltaTime;

        movePos.y = Mathf.Clamp(movePos.y, limits.x, limits.y);
        
        transform.position = movePos;
    }
}
