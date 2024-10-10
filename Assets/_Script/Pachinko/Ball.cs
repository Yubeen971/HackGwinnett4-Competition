using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bounceForce = 10f;  // 튀어오르는 힘

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        // 공을 발사하는 속도 설정 (x 방향은 무작위, y는 위로 발사)
        rb.velocity = new Vector2(Random.Range(-2f, 2f), 10f);
    }

    // 충돌 감지
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 만약 충돌한 블록이 "BouncyBlock" 태그를 가지고 있다면
        if (collision.gameObject.CompareTag("BouncyBlock"))
        {
            // 충돌 지점의 법선(normal)을 기준으로 튀어오르게 함
            Vector2 bounceDirection = collision.contacts[0].normal;
            rb.velocity = bounceDirection * bounceForce;
        }
    }
}
