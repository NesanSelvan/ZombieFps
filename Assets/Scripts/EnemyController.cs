using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent m_navmesh;
    private Animator m_animator;
    private PlayerManager m_playermanager;
    private float damage = 1f ;
    public GameManager m_gamemanager;
    public float health = 100;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //m_gamemanager = GetComponent<GameManager>();
        m_navmesh = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        m_animator = GetComponent<Animator>();
       m_playermanager =player.GetComponent<PlayerManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {


            m_navmesh.destination = player.transform.position;
        }
        
        if(m_navmesh.velocity.magnitude>1)
        {
            m_animator.SetBool("IsRunning", true);
        }
        else
        {
            m_animator.SetBool("IsRunning", false);
         
        }
        
       
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == player)
        {
            m_animator.SetBool("IsAttack", true);
             m_playermanager.Hit(damage);

        }
        else
        {
            m_animator.SetBool("IsAttack", false);
        }
    }
    public void Hit(float zombiedamage)
    {
        health -= zombiedamage;
       // Debug.Log("HEalth" + health);
        if(health<=0)
        {
            
            StartCoroutine(Dead());
            
          //  m_gamemanager.enemiesalive--;
        }
    }
   IEnumerator Dead()
    {
        
        m_animator.SetBool("IsDead", true);
      yield return new WaitForSeconds(4.5f);
        
        // m_navmesh.destination = transform.position;
        Destroy(gameObject);
    }
}
