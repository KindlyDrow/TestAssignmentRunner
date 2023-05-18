using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    /// <summary>
    /// When current torch changed
    /// arg1 - Current Torch Power
    /// arg2 - Initial Torch Power
    /// </summary>
    public event Action<float, float> OnTorchFading;
    public event Action<float> OnScoreChanged;

    [SerializeField] private float m_sideSpeed;
    [SerializeField] private float m_forwardSpeed;
    [SerializeField] private float m_initTorchPower;
    [SerializeField] private float m_initTorchFadingSpeed;
    [SerializeField] private float m_scoreAddingSpeed;

    private float m_score;
    private float m_currentTorchPower;
    public float ForwardSpeed { get { return m_forwardSpeed; } set { } }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        m_currentTorchPower = m_initTorchPower;
        GameInput.Instance.OnInputStarted += GameInput_OnInputStarted;
    }

    private void FixedUpdate()
    {
        ChangeScore(m_scoreAddingSpeed * Time.deltaTime);
        ChangeTorchPower(-m_initTorchFadingSpeed * Time.deltaTime);
    }

    private void GameInput_OnInputStarted(float axis)
    {
        Vector3 newPosition = new Vector3(transform.position.x + axis * m_sideSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        transform.position += Vector3.right * axis * m_sideSpeed * Time.deltaTime;
    }

    private void ChangeScore(float value)
    {
        m_score += value;
        OnScoreChanged?.Invoke(m_score);
    }

    private void ChangeTorchPower(float value)
    {
        m_currentTorchPower += value;
        OnTorchFading?.Invoke(m_currentTorchPower, m_initTorchPower);
    }
}
