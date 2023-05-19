using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private Button m_menuButton;
    [SerializeField] private Button m_restartButtom;

    private void Start()
    {
        m_menuButton.onClick.AddListener(Menu);
        m_restartButtom.onClick.AddListener(Restart);
    }

    private void Menu()
    {
        //TODO: Add something funny cuz there should be only one scene ;)
    }

    private void Restart()
    {
        UIManager.Instance.Restart();
    }

}
