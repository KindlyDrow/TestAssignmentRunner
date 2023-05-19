using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreEndGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private TextMeshProUGUI m_bestScoreText;
    [SerializeField] private Button m_closePreEndGameButton;

    private void Start()
    {
        m_closePreEndGameButton.onClick.AddListener(UIManager.Instance.HidePreEndGameUI);
    }


    private void OnEnable()
    {
        m_scoreText.text = Mathf.Ceil(GameManager.Instance.GetScore()).ToString();
        m_bestScoreText.text = Mathf.Ceil(GameManager.Instance.GetBestScore()).ToString();
    }
}
