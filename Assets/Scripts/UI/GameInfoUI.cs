using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameInfoUI : MonoBehaviour
{
    [SerializeField] private Image m_currentTorchAmount;
    [SerializeField] private TextMeshProUGUI m_scoreAmount;

    private void Awake()
    {
        
    }

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += GameManager_OnScoreChanged;
        GameManager.Instance.OnTorchFading += GameManager_OnTorchFading;
    }

    private void GameManager_OnTorchFading(float currentTorchPower, float initTorchPower)
    {
        m_currentTorchAmount.fillAmount = currentTorchPower / initTorchPower;
    }

    private void GameManager_OnScoreChanged(float score)
    {
        m_scoreAmount.text = Mathf.Ceil(score).ToString();
    }
}
