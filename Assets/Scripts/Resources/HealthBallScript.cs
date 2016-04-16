using UnityEngine;
using System.Collections;

public class HealthBallScript : MonoBehaviour {
    private int healthAmount = 5;
    public int healthMin = 2;
    public int healthMax = 25;
    public int secondsUntilDestruction = 5;

    void OnEnable() {
        healthAmount = Random.Range(healthMin, healthMax);
        Invoke("DestroyBall", secondsUntilDestruction);
    }

    void DestroyBall() {
        gameObject.SetActive(false);
    }

    void OnDisable() {
        CancelInvoke();
    }

    void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Player")) { 
            Debug.Log("Player should be getting additional health if possible.");
            PlayersHealth.playerHealth.Heal(healthAmount);
        //TODO: Up players health with current amount of this sphere
            Invoke("DestroyBall", .01f);
      }
    }
}