using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    public GameObject playercam;
    private EnemyController m_enemycontroller;
    public float zombiedamage = 100;
    public Animator m_animator;
    private int score = 0;
    public Text Scoretext;
    // Start is called before the first frame update
    void Start()
    {
       
        m_enemycontroller = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_animator.GetBool("IsShooting"))
        {
            m_animator.SetBool("IsShooting", false);
        }
       if(Input.GetKey(KeyCode.Mouse0))
        {
            shoot();
        }
        
    }
       private void shoot()
    {
        m_animator.SetBool("IsShooting", true);
        RaycastHit hit;

        if(Physics.Raycast(playercam.transform.position,transform.forward,out hit,1000))
        {
          m_enemycontroller =   hit.transform.GetComponent<EnemyController>();  
           if(m_enemycontroller != null)
            {
                m_enemycontroller.Hit(zombiedamage);
                score = score + 10;
                Scoretext.text = "Score:" + score.ToString();
            }
        }
    }
}
