using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private float bounceForce = 3f;      // 공이 튕겨 나갈 때의 기본 힘
    private float speedUpgrade = 1.0f;    // 속도 업그레이드 계수
    private float sizeUpgrade = 1.0f;     // 크기 업그레이드 계수
    private float controlTime = 2.0f;     // 조종 가능한 시간
    private bool isControllable = false;  // 공이 조종 가능한 상태인지 여부
    private float controlTimer;           // 조종 가능한 시간 타이머

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 크기 업그레이드 적용
        transform.localScale *= sizeUpgrade;

        // 공을 발사
        LaunchBall();

        // 공이 조종 가능한 시간 초기화
        controlTimer = controlTime;
        isControllable = true;
    }

    void Update()
    {
        // 공이 조종 가능한 상태일 때만 마우스 클릭으로 방향 조정 가능
        if (isControllable)
        {
            if (Input.GetMouseButtonDown(0))  // 마우스 클릭 시
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (mousePosition - transform.position).normalized;
                rb.velocity = direction * rb.velocity.magnitude;  // 속도 크기 유지하며 방향 조정
            }

            // 조종 가능한 시간이 경과하면 더 이상 조종 불가
            controlTimer -= Time.deltaTime;
            if (controlTimer <= 0)
            {
                isControllable = false;
            }
        }
    }

    void LaunchBall()
    {
        // 공을 발사하는 속도 설정 (x 방향은 무작위, y는 위로 발사)
        rb.velocity = new Vector2(Random.Range(-1f, 1f), 20f) * speedUpgrade;
    }

    // GameManager에서 업그레이드된 값들을 설정
    public void SetUpgradedValues(float speed, float size, float controlTime)
    {
        speedUpgrade = speed;
        sizeUpgrade = size;
        this.controlTime = controlTime;
    }

    // 충돌 처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BouncyBlock"))
        {
            // 충돌한 지점의 법선(normal)을 기준으로 공이 튕겨나가는 방향 설정
            Vector2 bounceDirection = collision.contacts[0].normal;

            // 튕겨 나가는 방향에 랜덤성을 추가
            Vector2 randomBounce = Random.insideUnitCircle * 0.5f;
            Vector2 finalBounceDirection = bounceDirection + randomBounce;

            // 방향을 정규화하고 새로운 속도를 적용
            finalBounceDirection.Normalize();
            rb.velocity = finalBounceDirection * bounceForce;
        }
    }
}
