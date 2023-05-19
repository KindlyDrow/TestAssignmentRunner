using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float m_sideSpeed;
    [SerializeField] private float m_forwardSpeed;

    public float ForwardSpeed { get { return m_forwardSpeed; } private set { } }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameInput.Instance.OnInputStarted += GameInput_OnInputStarted;
    }

    private void GameInput_OnInputStarted(float axis)
    {
        Vector3 newPosition = new Vector3(transform.position.x + axis * m_sideSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        transform.position += Vector3.right * axis * m_sideSpeed * Time.deltaTime;
    }
}
