using UnityEngine;
using System.Collections;

public class ManaBallScript : MonoBehaviour {
    private int manaAmount = 5;
    public int manaMin = 2;
    public int manaMax = 25;
    public int secondsUntilDestruction = 5;

    void OnEnable() {
        manaAmount = Random.Range(manaMin, manaMax);
        Invoke("DestroyBall", secondsUntilDestruction);
    }

    void DestroyBall() {
        gameObject.SetActive(false);
    }

    void OnDisable() {
        CancelInvoke();
    }

    void OnTriggerEnter(Collider col) {
      if(col.CompareTag("Player")){
        Debug.Log("Player should be getting additional energy if possible.");
        PlayersHealth.playerHealth.Manaize(manaAmount);
	    //TODO: Up players energy with current amount of this sphere
          Invoke("DestroyBall", .01f);
      }
	}
}