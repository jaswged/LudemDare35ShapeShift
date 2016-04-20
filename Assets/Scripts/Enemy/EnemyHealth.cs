using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
    public float hitPoints = 60;
    public bool isAlive = true;
    public float points = 50;
    public AudioClip[] deathClip;
    public AudioClip[] injuredClips;
    public float maxHealth = 60;
    Animator anim;
    public float timeToDie = 7;
    private static PauseMenu pauseMenu;
    private static GameObject player;

    public int enemyType;

    public float secondsUntilOffScreen = .5f;

    void Awake() {
        anim = GetComponent<Animator>();
    //TODO: test to make sure that this code works. 
        pauseMenu = pauseMenu ?? Camera.main.GetComponent<PauseMenu>();
        player = player ?? GameObject.FindGameObjectWithTag("Player");
        enemyType = getNewEnemyType();
        //HACK AI. fps = gameObject.GetComponent<FpsCompilation>();
    }

    void OnEnable(){ 
        hitPoints = maxHealth;
        isAlive = true;
        enemyType = getNewEnemyType();

    }

    void OnDisable(){  }

    public void TakeDamage(float damage, int damageType) {
        // if damage type is strong against this enemy do the damage.
        if (damageType == enemyType) {
            Debug.Log("Enemy took " + damage + " damage!");
            hitPoints -= damage;
        }

        if (hitPoints <= 0 && isAlive) {
            Debug.Log("Enemy is Dying now");
            Die();
        }
    }

    private int getNewEnemyType() {
        return Random.Range(1, 4);
    }

    void Die() {
        //anim.SetTrigger("isDead");
        AudioSource.PlayClipAtPoint(deathClip[Random.Range(0, deathClip.Length)], gameObject.transform.position, .8f);

#warning TODO This needs to be object pooled still?
        ///pauseMenu.enemies.Remove(gameObject);

         // Figure out which orb to drop
        int i = Random.Range(1,3);
        Debug.Log("Case for orb dropping: " + i);
        switch (i) {
            case 1:
                break;
            case 2:
                DropHealthOrb();
                break;
            case 3:
                DropManaOrb();
                break;
        }

        // set isAlive boolean to false
        isAlive = false;

        GameManagement.manage.increaseScore(points);
        GameManagement.manage.increaseKills();

        //Destroy(gameObject, timeToDie);
        this.enabled = false;

        Invoke("DieIMeanDisable", secondsUntilOffScreen);
    }

    private void DieIMeanDisable() {
        gameObject.SetActive(false);
    }

    internal void DropHealthOrb() {
        Debug.LogWarning("Dropping a health orb for the player.");
        GameObject obj = Pooling.POOL.GetHealthOrb();
        obj.transform.position = gameObject.transform.position;
        obj.SetActive(true);
    }

    internal void DropManaOrb() {
        Debug.LogWarning("Dropping a mana orb for the player.");
        GameObject obj = Pooling.POOL.GetManaOrb();
        obj.transform.position = gameObject.transform.position;
        obj.SetActive(true);
    }
}