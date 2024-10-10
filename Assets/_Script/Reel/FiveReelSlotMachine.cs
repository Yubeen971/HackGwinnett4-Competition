using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace
using System.Collections;

public class FiveReelSlotMachineTMP : MonoBehaviour
{
    public TextMeshProUGUI[] reelTexts;  // TMP components for the 5 reels
    public string[] symbols = { "1", "2", "3", "4", "5", "6", "7", "8" };  // Symbols to display
    public float spinDuration = 2f;  // Time the reels spin

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
