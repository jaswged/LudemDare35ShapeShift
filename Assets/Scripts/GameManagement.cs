using UnityEngine;
using System.Collections;

public class GameManagement : MonoBehaviour {
    #region new Variables
    public static GameManagement manage;
    private float score = 0f;
    private int kills = 0;
    public int timeToSpawn = 10;
    #endregion

    public int round = 1; //deprecate
    private int enemiesInRound = 10;
    private int enemeisSpawnedInRound = 0;
    private float enemySpawnTimer = 0f;
    public GameObject enemyEthan;

    public Transform[] enemySpawnPoints;

    void Awake() {
        if (manage == null) {
            DontDestroyOnLoad(gameObject);
            manage = this;
        }
        else if (manage != this) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update ()  {
	    if(enemeisSpawnedInRound < enemiesInRound)  {
            if(enemySpawnTimer > timeToSpawn) {
                SpawnEnemy();
                enemySpawnTimer = 0f;
            }
            else{
                enemySpawnTimer += Time.deltaTime;
            }
        }
	}

    void SpawnEnemy() {
        Vector3 randomSpawnPoint = enemySpawnPoints[Random.Range(0,enemySpawnPoints.Length)].position;
        Instantiate(enemyEthan, randomSpawnPoint, Quaternion.identity);
        enemiesInRound++;
    }

    public void increaseScore(float pScore) {
        this.score += pScore;
    }

    public void increaseKills() {
        kills++;
    }

    public float getScore() {
        return score;
    }

    public int getKills() {
        return kills;
    }
}