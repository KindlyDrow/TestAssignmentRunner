using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCharge : MonoBehaviour, IPickupable
{
    [SerializeField] private float m_torchPower;
    [SerializeField] private float m_score;

    public void OnPickup()
    {
        GameManager.Instance.ChangeScore(m_score);
        GameManager.Instance.ChangeTorchPower(m_torchPower);
        Destroy(gameObject);
    }
}
