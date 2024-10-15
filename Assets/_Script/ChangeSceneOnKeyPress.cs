using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 전환을 위해 필요

public class ChangeSceneOnKeyPress : MonoBehaviour
{
    public string sceneName;  // 전환하고자 하는 씬의 이름
    public int pressCountToSwitch = 5;  // 특정 키를 몇 번 눌러야 씬이 전환되는지
    private int currentPressCount = 0;  // 현재 누른 횟수 저장

    void Update()
    {
        // 키보드에서 'J' 키가 눌렸을 때 카운트 증가
        if (Input.GetKeyDown(KeyCode.J))
        {
            currentPressCount++;

            Debug.Log("J 키를 눌렀습니다. 현재 카운트: " + currentPressCount);

            // 카운트가 설정한 횟수에 도달하면 씬 전환
            if (currentPressCount >= pressCountToSwitch)
            {
                Debug.Log("씬을 전환합니다: " + sceneName);
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
