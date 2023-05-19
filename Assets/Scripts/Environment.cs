using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private float m_speed;
    private bool gameStarted;

    virtual public void Start()
    {
        m_speed = Player.Instance.ForwardSpeed;
    }

    virtual public void FixedUpdate()
    {
        if (GameManager.Instance.CurrentState == GameManager.State.GameInProgress)
        {
            transform.position += Vector3.back * m_speed * Time.deltaTime;
        }
    }

    public void Return()
    {
        EnvironmentFuctory.Instance.ReturnEnviroment(gameObject);
    }
}
