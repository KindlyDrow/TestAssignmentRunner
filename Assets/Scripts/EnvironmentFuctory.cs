using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnvironmentFuctory : MonoBehaviour
{
    public static EnvironmentFuctory Instance { get; private set; }

    [SerializeField] private GameObject m_emptuEnvironmentPrefab;
    [SerializeField] private int m_initialEmptyEnvironmentPoolSize;
    private List<GameObject> m_emptyEnvironmentPool;

    [SerializeField] private GameObject[] m_environmentPrefabs;
    [SerializeField] private int m_initialEnvironmentPoolSize;
    private List<GameObject>[] m_environmentPools;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CreateEmptyEnvironmentPool();
        CreateEnvironmentPool();
    }

    private void CreateEmptyEnvironmentPool()
    {
        m_emptyEnvironmentPool = new List<GameObject>();

        for (int j = 0; j < m_initialEmptyEnvironmentPoolSize; j++)
        {
            GameObject enviroment = Instantiate(m_emptuEnvironmentPrefab);
            enviroment.SetActive(false);
            m_emptyEnvironmentPool.Add(enviroment);
        }
    }

    private void CreateEnvironmentPool()
    {
        m_environmentPools = new List<GameObject>[m_environmentPrefabs.Length];

        for (int i = 0; i < m_environmentPrefabs.Length; i++) 
        {
            m_environmentPools[i] = new List<GameObject>();

            for (int j = 0; j < m_initialEnvironmentPoolSize; j++)
            {
                GameObject enviroment = Instantiate(m_environmentPrefabs[i]);
                enviroment.SetActive(false);
                m_environmentPools[i].Add(enviroment);
            }

        }
    }

    public GameObject GetEmptyEnviroment()
    {
        for (int i = 0; i < m_emptyEnvironmentPool.Count; i++)
        {
            if (!m_emptyEnvironmentPool[i].activeSelf)
            {
                return m_emptyEnvironmentPool[i];
            }
        }

        GameObject bullet = Instantiate(m_emptuEnvironmentPrefab);
        bullet.SetActive(false);
        m_emptyEnvironmentPool.Add(bullet);
        return bullet;
    }

    public void ReturnEnviroment(GameObject enviromentToReturn)
    {
        enviromentToReturn.SetActive(false);
        enviromentToReturn.transform.SetParent(null);
    }

}
