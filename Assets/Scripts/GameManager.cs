using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const string PLAYER_BEST_SCORE_PLAYER_PREFS = "PlayerBestScore";

    public static GameManager Instance { get; private set; }

    /// <summary>
    /// When current torch changed
    /// arg1 - Current Torch Power
    /// arg2 - Initial Torch Power
    /// </summary>
    public event Action<float, float> OnTorchFading;
    public event Action<float> OnScoreChanged;
    public event Action OnCountdownStarted;
    public event Action<float> OnCountdownTimerChanged;
    public event Action OnCountdownEnded;
    public event Action OnGameStarted;
    public event Action OnGameEnded;

    public enum State
    {
        GamePreparing = default,
        GameCountDown,
        GameInProgress,
        GamePoused,
        GameEnd,
    }

    private State m_state;
    public State CurrentState { get { return m_state; } private set { } }

    [SerializeField] private float m_initTorchPower;
    [SerializeField] private float m_initTorchFadingSpeed;
    [SerializeField] private float m_initScoreAddingSpeed;
    [SerializeField] private float m_initCountdownTimer;

    private float m_score;
    private float m_currentTorchPower;
    private float m_currentCountdowntTimer;

    private void Awake()
    {
        Instance = this;
        ChangeState(State.GamePreparing);
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        switch (m_state)
        {
            case State.GamePreparing:
                ChangeState(State.GameCountDown);

                break;

            case State.GameCountDown:
                m_currentCountdowntTimer -= Time.deltaTime;
                OnCountdownTimerChanged?.Invoke(m_currentCountdowntTimer);
                if (m_currentCountdowntTimer < 0)
                {
                    ChangeState(State.GameInProgress);
                }

                break;

            case State.GameInProgress:
                ChangeScore(m_initScoreAddingSpeed * Time.deltaTime);
                ChangeTorchPower(-m_initTorchFadingSpeed * Time.deltaTime);

                break;

            case State.GamePoused:
                break;

            case State.GameEnd:
                break;
        }
    }

    private void ChangeState(State state)
    {
        switch (state)
        {
            case State.GamePreparing:
                Time.timeScale = 1f;
                m_currentTorchPower = m_initTorchPower;
                break;

            case State.GameCountDown:
                m_currentCountdowntTimer = m_initCountdownTimer;
                OnCountdownStarted?.Invoke();
                break;

            case State.GameInProgress:
                OnGameStarted?.Invoke();               
                Time.timeScale = 1f;

                break;

            case State.GamePoused:
                Time.timeScale = 0f;

                break;

            case State.GameEnd:
                if (m_score > GetBestScore())
                {
                    SetBestScore(m_score);
                }
                OnGameEnded?.Invoke();
                Time.timeScale = 0f;

                break;
        }
        EndState(m_state);
        m_state = state;
    }

    private void EndState(State state)
    {
        switch (state)
        {
            case State.GamePreparing:
                break;

            case State.GameCountDown:
                OnCountdownEnded?.Invoke();

                break;

            case State.GameInProgress:
                break;

            case State.GamePoused:

                break;

            case State.GameEnd:
                break;
        }
    }
    public void ChangeScore(float value)
    {
        m_score += value;
        OnScoreChanged?.Invoke(m_score);
    }

    public void ChangeTorchPower(float value)
    {
        m_currentTorchPower += value;
        if (m_currentTorchPower < 0f)
        {
            ChangeState(State.GameEnd);
        } else
        {
            OnTorchFading?.Invoke(m_currentTorchPower, m_initTorchPower);
        }
    }

    public void PouseGame()
    {
        ChangeState(State.GamePoused);
    }

    public void UnPouseGame()
    {
        ChangeState(State.GameInProgress);
    }

    public float GetScore()
    {
        return m_score;
    }

    private void SetBestScore(float value)
    {
        PlayerPrefs.SetInt(PLAYER_BEST_SCORE_PLAYER_PREFS, Mathf.CeilToInt(value));
    }

    public float GetBestScore()
    {
        return PlayerPrefs.GetInt(PLAYER_BEST_SCORE_PLAYER_PREFS);
    }
}