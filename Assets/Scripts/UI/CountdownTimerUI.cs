using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_countdownTimerText;

    private void Start()
    {
        GameManager.Instance.OnCountdownTimerChanged += GameManager_OnCountdownTimerChanged;
    }

    private void GameManager_OnCountdownTimerChanged(float timer)
    {
        m_countdownTimerText.text = Mathf.Ceil(timer).ToString();
    }

}
