using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHandler : MonoBehaviour
{
    [SerializeField] private float m_environmentSize;
    [SerializeField] private Transform m_environment;
    private bool m_isPrevEmpty = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Environment>(out Environment environment))
        {
            environment.Return();
            AddNewInvironment(other.transform.position);
        } else
        {
            Debug.Log("SMTH GO WRNG!!!");
        }
    }

    private void AddNewInvironment(Vector3 trigerPos)
    {
        int EnvCount = m_environment.childCount;
        GameObject newEnv;

        if (!m_isPrevEmpty)
        {
            newEnv = EnvironmentFuctory.Instance.GetEmptyEnviroment();
            m_isPrevEmpty = true;
        }

        int randomEnv = Random.Range(0, 3);

        newEnv = (randomEnv == 0) ? EnvironmentFuctory.Instance.GetEmptyEnviroment() : EnvironmentFuctory.Instance.GetRandomEnviroment();

        newEnv.transform.SetParent(m_environment);
        newEnv.transform.position = new Vector3(m_environment.position.x, m_environment.position.y, trigerPos.z + m_environmentSize *  EnvCount);
        newEnv.SetActive(true);
    }
}
