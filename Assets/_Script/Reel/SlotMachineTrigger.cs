using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineTrigger : MonoBehaviour
{
    public GameObject slotMachineUI;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            slotMachineUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            slotMachineUI.SetActive(false);
        }
    }
}
