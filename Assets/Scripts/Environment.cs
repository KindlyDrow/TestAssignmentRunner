using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private float m_speed;

    virtual public void Start()
    {
        m_speed = Player.Instance.ForwardSpeed;
    }

    virtual public void FixedUpdate()
    {
        transform.position += Vector3.back * m_speed * Time.deltaTime;
    }

    public void Return()
    {
        EnvironmentFuctory.Instance.ReturnEnviroment(gameObject);
    }
}
