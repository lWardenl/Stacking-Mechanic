using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

public class BuildingCanvas : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private TMP_Text amountText;

    public int collectedAmount;

    public int requiredAmount;

    void Start()
    {
        progressBar.value = collectedAmount / requiredAmount;
        amountText.text = $"{collectedAmount}/{requiredAmount}";
    }

    public void Add(int value)
    {
        collectedAmount += value;

        progressBar.value = collectedAmount * 1.0f / requiredAmount;
        amountText.text = $"{collectedAmount}/{requiredAmount}";
    }
}

