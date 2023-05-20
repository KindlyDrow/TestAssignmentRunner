using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour, IDamaging
{
    [SerializeField] private float m_damage;

    public void TakeDamage()
    {
        GameManager.Instance.ChangeTorchPower(-m_damage * Time.deltaTime);
    }
}
