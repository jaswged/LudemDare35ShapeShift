using UnityEngine;
using System.Collections;

public class HackEnemyHealth : MonoBehaviour {
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

    public float secondsUntilOffScreen = 3;

    void Awake() {
        anim = GetComponent<Animator>();
    //TODO: test to make sure that this code works. 
        pauseMenu = pauseMenu ?? Camera.main.GetComponent<PauseMenu>();
        player = player ?? GameObject.FindGameObjectWithTag("Player");
        //HACK AI. fps = gameObject.GetComponent<FpsCompilation>();
    }

    void OnEnable(){ 
        hitPoints = maxHealth;
        isAlive = true;
    }

    void OnDisable(){  }

    public void TakeDamage(float damage) {
        Debug.Log("Enemy took " + damage + " damage!");
        hitPoints -= damage;
        if (hitPoints <= 0 && isAlive) {
            Debug.Log("Enemy is Dying now");
            Die();
        }
    }

    void Die() {
        anim.SetTrigger("isDead");
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
                DropEnergyOrb();
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
        Debug.LogError("Dropping Health Orb");
        GameObject obj = Pooling.POOL.GetHealthOrb();
        obj.transform.position = gameObject.transform.position;
        obj.SetActive(true);
        print("Drop Health orb yo");
        Debug.LogError("Dropping a health orb for the player.");
    #warning TODO tadone?
    }

    internal void DropEnergyOrb() {
        Debug.LogError("Dropping Energy Orb");
        GameObject obj = Pooling.POOL.GetEnergyOrb();
        obj.transform.position = gameObject.transform.position;
        obj.SetActive(true);
        print("Drop Energy orb yo");
        Debug.LogError("Dropping an energy orb for the player.");
#warning TODO TaDone?
    }
}