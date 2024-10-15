using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI coinText;        // UI에서 사용할 TextMeshProUGUI
    public TextMeshPro countdownText;       // 게임 오브젝트에 있는 TextMeshPro (카운트다운)
    public TextMeshProUGUI speedUpgradeText;   // 속도 업그레이드 UI
    public TextMeshProUGUI sizeUpgradeText;    // 크기 업그레이드 UI
    public TextMeshProUGUI scoreUpgradeText;   // 점수 업그레이드 UI
    public TextMeshProUGUI controlTimeUpgradeText; // 조종 시간 업그레이드 U


    public GameObject ballPrefab;
    public Transform spawnPosition;

    private int coins = 0;

    // 업그레이드 관련 변수
    public float ballSpeedUpgrade = 1.0f;  // 공 속도 업그레이드 계수
    public float ballSizeUpgrade = 1.0f;   // 공 크기 업그레이드 계수
    public int scoreMultiplier = 1;        // 점수 증가 계수
    public float controlTime = 2.0f;       // 공 조종 시간 (기본 2초)

    // 업그레이드 레벨
    private int speedLevel = 0;
    private int sizeLevel = 0;
    private int scoreLevel = 0;
    private int controlTimeLevel = 0;

    // 업그레이드에 필요한 코인 비용 (초기 비용)
    private int speedUpgradeCost = 10;
    private int sizeUpgradeCost = 10;
    private int scoreUpgradeCost = 15;
    public int controlTimeUpgradeCost = 20;


    // 스폰 쿨다운 관련 변수
    public float spawnCooldown = 3.0f;     // 3초 쿨다운
    private float spawnTimer = 0f;         // 현재 타이머

    // UI 관련 변수
    public Button speedUpgradeButton;
    public Button sizeUpgradeButton;
    public Button scoreUpgradeButton;
    public Button controlTimeUpgradeButton;

    // 비용 증가율
    private float costIncreaseRate = 1.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        speedUpgradeButton.onClick.AddListener(UpgradeBallSpeed);
        sizeUpgradeButton.onClick.AddListener(UpgradeBallSize);
        scoreUpgradeButton.onClick.AddListener(UpgradeScoreMultiplier);
        controlTimeUpgradeButton.onClick.AddListener(UpgradeControlTime);

        UpdateCoinText();
        UpdateCountdownText();  // 초기 카운트다운 텍스트 업데이트
        UpdateUI();
    }

    void Update()
    {
        // 타이머가 0보다 크면 감소
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            UpdateCountdownText();  // 카운트다운 텍스트 업데이트
        }

        // 스페이스 키를 눌렀고, 타이머가 0 이하일 때만 공을 스폰
        if (Input.GetKeyDown(KeyCode.Space) && spawnTimer <= 0)
        {
            SpawnBall();
            spawnTimer = spawnCooldown; // 타이머를 3초로 초기화
        }

        // 타이머가 0 이하일 때는 "/\" 표시
        if (spawnTimer <= 0)
        {
            countdownText.text = "/\\";
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;  // 코인 추가
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + coins.ToString();
    }

    void UpdateUI()
    {
        // 각 업그레이드의 레벨과 비용 표시
        speedUpgradeText.text = speedLevel + " LV Speed Upgrade\n$" + speedUpgradeCost;
        sizeUpgradeText.text = sizeLevel + " LV Size Upgrade\n$" + sizeUpgradeCost;
        scoreUpgradeText.text = scoreLevel + " LV Score Upgrade\n$" + scoreUpgradeCost;
        controlTimeUpgradeText.text = controlTimeLevel + " LV Control Time Upgrade\n$" + controlTimeUpgradeCost;

        UpdateCoinText();
    }

    // 공 속도 업그레이드
    public void UpgradeBallSpeed()
    {
        if (coins >= speedUpgradeCost)
        {
            ballSpeedUpgrade += 0.2f;  // 속도 증가
            coins -= speedUpgradeCost; // 코인 차감
            speedLevel++;              // 레벨 증가
            speedUpgradeCost = Mathf.CeilToInt(speedUpgradeCost * costIncreaseRate);  // 비용 증가
            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough coins for speed upgrade.");
        }
    }

    // 공 크기 업그레이드
    public void UpgradeBallSize()
    {
        if (coins >= sizeUpgradeCost)
        {
            ballSizeUpgrade += 0.2f;   // 크기 증가
            coins -= sizeUpgradeCost;  // 코인 차감
            sizeLevel++;               // 레벨 증가
            sizeUpgradeCost = Mathf.CeilToInt(sizeUpgradeCost * costIncreaseRate);  // 비용 증가
            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough coins for size upgrade.");
        }
    }

    // 점수 증가 업그레이드
    public void UpgradeScoreMultiplier()
    {
        if (coins >= scoreUpgradeCost)
        {
            scoreMultiplier += 1;      // 점수 증가 배율
            coins -= scoreUpgradeCost; // 코인 차감
            scoreLevel++;              // 레벨 증가
            scoreUpgradeCost = Mathf.CeilToInt(scoreUpgradeCost * costIncreaseRate);  // 비용 증가
            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough coins for score multiplier upgrade.");
        }
    }

    // 공 끌어당기는 힘 업그레이드
    public void UpgradeControlTime()
    {
        if (coins >= controlTimeUpgradeCost)
        {
            controlTime += 1.0f;  // 공을 조종할 수 있는 시간을 1초씩 증가
            coins -= controlTimeUpgradeCost; // 코인 차감
            controlTimeLevel++;              // 레벨 증가
            controlTimeUpgradeCost = Mathf.CeilToInt(controlTimeUpgradeCost * costIncreaseRate);  // 비용 증가
            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough coins for control time upgrade.");
        }
    }

    void SpawnBall()
    {
        // 공을 설정된 위치에 새로 생성
        GameObject newBall = Instantiate(ballPrefab, spawnPosition.position, Quaternion.identity);

        // Ball 스크립트에 업그레이드 적용
        Ball ballScript = newBall.GetComponent<Ball>();
        ballScript.SetUpgradedValues(ballSpeedUpgrade, ballSizeUpgrade, controlTime);
    }


    void UpdateCountdownText()
    {
        if (spawnTimer > 0)
        {
            countdownText.text = Mathf.Ceil(spawnTimer).ToString();  // 소수점을 버리고 정수로 표시
        }
        else
        {
            countdownText.text = "/\\";
        }
    }
}
