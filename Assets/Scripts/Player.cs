using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private Light m_torch;
    private float m_initIntensity;
    [SerializeField] private float m_torchLowestIntensity = 0.5f;

    [SerializeField] private float m_sideSpeed;
    [SerializeField] private float m_forwardSpeed;

    [SerializeField] private float m_maxX;

    public float ForwardSpeed { get { return m_forwardSpeed; } private set { } }

    private void Awake()
    {
        Instance = this;
        m_initIntensity = m_torch.intensity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IPickupable>(out IPickupable pickupable))
        {
            pickupable.OnPickup();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<IDamaging>(out IDamaging damaging))
        {
            damaging.TakeDamage();
        }
    }

    private void Start()
    {
        GameInput.Instance.OnInputStarted += GameInput_OnInputStarted;
        GameManager.Instance.OnTorchFading += GameManager_OnTorchFading;
    }

    private void GameManager_OnTorchFading(float arg1, float arg2)
    {
        if (m_torch.intensity > m_torchLowestIntensity)
        {
            m_torch.intensity = m_initIntensity * (arg1 / arg2);
        }
    }

    private void GameInput_OnInputStarted(float axis)
    {
        float newPoxX = Mathf.Clamp(transform.position.x + axis * m_sideSpeed * Time.deltaTime, -m_maxX, m_maxX);

        transform.position = new Vector3(newPoxX, transform.position.y, transform.position.z);
    }

    
}
