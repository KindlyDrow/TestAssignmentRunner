using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] GameObject m_countDownTimer;
    [SerializeField] GameObject m_pouseMenu;
    [SerializeField] GameObject m_inGameUI;
    [SerializeField] GameObject m_preEndGameUI;
    [SerializeField] GameObject m_endGameUI;

    [SerializeField] Button m_inGamePouseButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        HideAll();
    }

    private void Start()
    {
        m_inGamePouseButton.onClick.AddListener(PouseGame);

        GameManager.Instance.OnCountdownStarted += GameManager_OnCountdownStarted;
        GameManager.Instance.OnCountdownEnded += GameManager_OnCountdownEnded;
        GameManager.Instance.OnGameStarted += GameManager_OnGameStarted;
        GameManager.Instance.OnGameEnded += GameManager_OnGameEnded;
    }

    private void GameManager_OnGameEnded()
    {
        HideAll();
        Show(m_preEndGameUI);
    }

    private void GameManager_OnGameStarted()
    {
        HideAll();
        Show(m_inGameUI);
    }

    private void GameManager_OnCountdownEnded()
    {
        Hide(m_countDownTimer);
    }

    private void GameManager_OnCountdownStarted()
    {
        Show(m_countDownTimer);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        HidePouseMenu();
        GameManager.Instance.UnPouseGame();
    }

    private void PouseGame()
    {
        GameManager.Instance.PouseGame();
        HideAll();
        Show(m_pouseMenu);
    }

    private void HidePouseMenu()
    {
        Hide(m_pouseMenu);
        Show(m_inGameUI);
    }

    public void HidePreEndGameUI()
    {
        Hide(m_preEndGameUI);
        Show(m_endGameUI);
    }

    private void HideAll()
    {
        Hide(m_inGameUI);
        Hide(m_pouseMenu);
        Hide(m_countDownTimer);
        Hide(m_preEndGameUI);
        Hide(m_endGameUI);
    }

    private void Hide(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    private void Show(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
