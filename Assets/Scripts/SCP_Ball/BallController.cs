using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public Vector2 startVel = new Vector2(5, 5);
    private float startSpeed;
    public float speed = 2;
    private Rigidbody2D _rb;
    public bool enemyPaddleCanMove = true;

    void Awake()
    {
        startSpeed = speed;
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;

        //Reset Speed
        speed = startSpeed;

        //randomize the ball direction in the start, and the lode side receive the ball
        startVel.y = Random.Range(-startVel.y, startVel.y);

        //if enemy score make the startVel.x negative '-5', giving the ball to the player
        if(!enemyPaddleCanMove)
            startVel.x *= -1;
            
        //Make the ball move
        if(_rb == null) _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = startVel;

        //after give the ball to player, return to the default value '5' 
        startVel.x *= -1;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, -_rb.velocity.y);

            var wall = collision.gameObject.GetComponent<PointCounter>();
            if(wall != null)
                GameManager.Instance.SideScore(wall.side);
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            enemyPaddleCanMove = true;
            var paddle = collision.transform.GetComponent<PaddlesBase>();
            if(paddle.paddleDir != null)
                MyPaddleCollide(paddle.paddleDir);
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            // EnemyPaddleCollide(collision.transform);
            enemyPaddleCanMove = false;
            var paddle = collision.transform.GetComponent<PaddlesBase>();
            if(paddle.paddleDir != null)
                MyPaddleCollide(paddle.paddleDir);
        }
    }

    void MyPaddleCollide(Transform t)
    {
        Vector2 collideDir =  transform.position - t.position;
        _rb.velocity = collideDir.normalized * speed;
        speed *= 1.1f;
    }

    void EBACPaddleCollide()
    {
        _rb.velocity = new Vector2(-_rb.velocity.x, _rb.velocity.y);
        _rb.velocity *= 1.1f;
    }
}
