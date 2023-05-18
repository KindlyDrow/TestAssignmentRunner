using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event Action<float> OnInputStarted;

    private PlayerInput m_playerInput;

    private void Awake()
    {
        Instance = this;
        m_playerInput = new PlayerInput();
        m_playerInput.Move.GetAxis.started += GetAxis_started;
    }

    private void GetAxis_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInputStarted?.Invoke(obj.ReadValue<float>());
    }

    void OnEnable()
    {
        m_playerInput.Enable();
    }

    void OnDisable()
    {
        m_playerInput.Disable();
    }
}
