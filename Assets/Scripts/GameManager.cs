using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemiesalive = 0;
    public int round = 0;
    public int currentround = 0;
    public GameObject[] Zombie;
    public GameObject[] SpawnPoints;
    public GameObject enemyprefab;
    public Text roundNumber;
    public GameObject endscreen;
    // Start is called before the first frame update
    void Start()
    {
       
        //for (int i = 0; i < SpawnPoints.Length; i++)
        //{
        //    SpawnPoints[i] = transform.GetChild(i).gameObject;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        Zombie = GameObject.FindGameObjectsWithTag("Zombie");
       
        //Debug.Log(Zombie.Length);
        // Debug.Log(enemiesalive);
        //if (enemiesalive <=2)
        //{
            if (Zombie.Length == 0 && Zombie.Length <= 10)
            {
            NextWave();
            //round++;
        }
      //  }
        //else
        //{
        //    currentround++;
        //    Debug.Log("Round" + currentround);
        //    roundNumber.text = "Round: " + currentround.ToString();
        //}

        //if(enemiesalive == 2)
        //{
           // if(Zombie.Length ==0)
            //{
            
            //}
        //}
    }
    private void SpawnZombies()
    {
      
            GameObject spawnpoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            GameObject enemyspawned = Instantiate(enemyprefab, spawnpoint.transform.position, Quaternion.identity);
            enemyspawned.GetComponent<EnemyController>().m_gamemanager = GetComponent<GameManager>();
            enemiesalive++;
            Debug.Log("Enemies"+ enemiesalive);
      
        
    }
    private void NextWave()
    {
       for(int i = 0;i<10;i++)
        {
            SpawnZombies();
        }
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        endscreen.SetActive(true); 
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

