using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ShapeShift;

public class PlayersHealth : MonoBehaviour{
    #region Mage variables
    public static PlayersHealth playerHealth;
    //[HideInInspector]
    public float health = 100f;
    public float maxHealth = 1000;
    public float resetAfterDeathTime = 5f;// How much time from the player dying to the level reseting.
    public AudioClip deathClip;			// The sound effect of the player dying.
    public AudioClip[] injuredClip;	
    public Texture damageTexture;       // The gui overlay of bloody death
    private float timer;				// A timer for counting to the reset of the level once the player is dead.
    public bool isDead;
    public float healthToShowTextureAt = 210;

    public float maxEnergy = 100;
    public float mana = 100;
    public bool isHack;
    public Slider healthBarSlider;
    public Slider energySlider;
    #endregion

    void Awake(){
        playerHealth = this;
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = health;
        energySlider.maxValue = maxEnergy;
        energySlider.value = mana;
    }

	// Update is called once per frame
	void Update () {
        healthBarSlider.value = health;
        energySlider.value = mana;

        if (health <= 0f){
            if (!isDead)
                PlayerDying();
        }
	}

    private void PlayerDying() {
        isDead = true;
        AudioSource.PlayClipAtPoint(deathClip, transform.position);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Screen.lockCursor = false;
            
        gameObject.GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0;
    }

    public void TakeDamage(float amount){
        // Decrement the player's health by amount.
        health -= amount;
        AudioSource.PlayClipAtPoint(injuredClip[Random.Range(0,injuredClip.Length)], transform.position);
    }

    void OnGUI() {
        if(isDead) {
            GUI.color = Color.white;

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");

            GUILayout.BeginArea(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 400, 400));

            if (GUILayout.Button("Restart")) {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                //Screen.lockCursor = false;
                Application.LoadLevel(Application.loadedLevel);
            }

            if (GUILayout.Button("Quit to Main Menu")) {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //Screen.lockCursor = false;
                Application.LoadLevel(Constants.MAIN_MENU);
            }

            GUILayout.EndArea();
            Time.timeScale = 0;
        }
        else if (health < healthToShowTextureAt)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), damageTexture);
    }

#region Mage methods
    /** Called by hack health ball */
    internal void Heal(int healthAmount) {
        health += healthAmount;
        if(health > maxHealth)
            health = maxHealth;
        Debug.Log("Health is now: " + health);
    }
    /** Called by hack Energy ball */
    internal void Manaize(int manaAmount) {
        mana += manaAmount;
        if (mana > maxEnergy)
            mana = maxEnergy;
        Debug.Log("Energy is now: " + mana);
    }
#endregion
}