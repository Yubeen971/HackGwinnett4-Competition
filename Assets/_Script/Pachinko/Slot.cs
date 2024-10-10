using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int scoreValue;  // 각 슬롯의 점수 값

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 공이 슬롯에 들어가면 점수 추가
            GameManager.instance.AddScore(scoreValue);
            Destroy(collision.gameObject); // 공을 파괴하거나 재사용할 수 있습니다.
        }
    }
}
