using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText;  // TextMeshProUGUI로 변경
    public GameObject ballPrefab;      // 공 프리팹
    public Transform spawnPosition;    // 공이 생성될 위치

    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        // Space 키 입력을 감지하여 공 생성
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBall();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();  // 점수 표시
    }

    void SpawnBall()
    {
        // 공을 설정된 위치에 새로 생성
        Instantiate(ballPrefab, spawnPosition.position, Quaternion.identity);
    }

}
