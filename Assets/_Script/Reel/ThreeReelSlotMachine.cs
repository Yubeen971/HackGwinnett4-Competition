using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using System.Collections;

public class ThreeReelSlotMachineTMP : MonoBehaviour
{
    public TextMeshProUGUI[] reelTexts;  // TMP components for the 3 reels
    public string[] symbols = { "A", "B", "C", "D", "E", "F" };  // Symbols to display
    public float spinDuration = 1.5f;  // Time the reels spin

    private bool isSpinning = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSpinning)
        {
            StartCoroutine(SpinReels());
        }
    }

    IEnumerator SpinReels()
    {
        isSpinning = true;

        for (int i = 0; i < reelTexts.Length; i++)
        {
            yield return StartCoroutine(SpinSingleReel(reelTexts[i]));
        }

        isSpinning = false;
    }

    IEnumerator SpinSingleReel(TextMeshProUGUI reelText)
    {
        float elapsedTime = 0f;
        while (elapsedTime < spinDuration)
        {
            reelText.text = symbols[Random.Range(0, symbols.Length)];
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
