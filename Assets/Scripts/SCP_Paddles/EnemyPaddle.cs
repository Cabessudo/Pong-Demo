using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddle : PaddlesBase
{
    private Rigidbody2D _rb;
    private BallController ball;
    public bool enemyPlayer = false;

    void Start()
    {
        paddleSprite.color = SaveController.Instance.enemyColor;
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void Movement()
    {
        if(enemyPlayer)
            EnemyMovement();
        else
            EnemyMovementAI();
    }

    void EnemyMovement()
    {
        float inputY = Input.GetAxis("Vertical2");

        Vector2 movePos = transform.position + Vector3.up * inputY * speed * Time.deltaTime;

        movePos.y = Mathf.Clamp(movePos.y, limits.x, limits.y);
        
        transform.position = movePos;
    }

    void EnemyMovementAI()
    {
        if(ball != null)
        {
            if(ball.enemyPaddleCanMove)
            {
                //limits.x is the limit to go down, and the limits.y is up
                float ballPosY = Mathf.Clamp(ball.transform.position.y, limits.x, limits.y);  
                
                Vector2 ballPos = new Vector2(transform.position.x, ballPosY);
                
                transform.position = Vector2.Lerp(transform.position, ballPos, Time.deltaTime * speed);
            }
        }
    } 
}
