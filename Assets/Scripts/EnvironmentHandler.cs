using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHandler : MonoBehaviour
{
    [SerializeField] private float m_environmentSize;
    [SerializeField] private Transform m_environment;

    private void OnTriggerEnter(Collider other)
    {
        Environment environment = other.GetComponentInParent<Environment>();
        environment.Return();
        AddNewInvironment(other.transform.position);
    }

    private void AddNewInvironment(Vector3 trigerPos)
    {
        int EnvCount = m_environment.childCount + 1;
        GameObject newEnv;

        newEnv = EnvironmentFuctory.Instance.GetEmptyEnviroment();
        newEnv.transform.SetParent(m_environment);
        newEnv.transform.position = new Vector3(m_environment.position.x, m_environment.position.y, trigerPos.z + m_environmentSize *  EnvCount);
        newEnv.SetActive(true);
    }
}
