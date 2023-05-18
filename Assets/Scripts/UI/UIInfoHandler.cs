using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInfoHandler : MonoBehaviour
{
    [SerializeField] private Image m_currentTorchAmount;
    [SerializeField] private TextMeshProUGUI m_scoreAmount;

    private void Start()
    {
        Player.Instance.OnTorchFading += Player_OnTorchFading;
        Player.Instance.OnScoreChanged += Player_OnScoreChanged;
    }

    private void Player_OnScoreChanged(float obj)
    {
        m_scoreAmount.text = Mathf.Ceil(obj).ToString();
    }

    private void Player_OnTorchFading(float arg1, float arg2)
    {
        m_currentTorchAmount.fillAmount = arg1/arg2;
    }
}
