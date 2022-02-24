using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float Health = 500;
    public Text HealthTxt;
    public GameManager m_gamemanager;
    
    public void Hit(float damage)
    {
        Health -= damage;
        HealthTxt.text = "Health:"+ Health.ToString();
        if(Health<=0)
        {
            m_gamemanager.EndGame();
        }
    }
  
}