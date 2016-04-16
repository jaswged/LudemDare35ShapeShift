using UnityEngine;
using System.Collections;

public class GameManagement : MonoBehaviour 
{
    public int round = 1; //deprecate
    private int enemiesInRound = 10;
    private int enemeisSpawnedInRound = 0;
    private float enemySpawnTimer = 0f;
    public GameObject enemyEthan;

    public Transform[] enemySpawnPoints;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(enemeisSpawnedInRound < enemiesInRound)
        {
            if(enemySpawnTimer > 20)
            {
                SpawnEnemy();
                enemySpawnTimer = 0f;
            }
            else
            {
                enemySpawnTimer+=Time.deltaTime;
            }
        }
	}

    void SpawnEnemy()
    {
    Vector3 randomSpawnPoint = enemySpawnPoints[Random.Range(0,enemySpawnPoints.Length)].position;
    Instantiate(enemyEthan, randomSpawnPoint, Quaternion.identity);
    enemiesInRound++;
    }
}