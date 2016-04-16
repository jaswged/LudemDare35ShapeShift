using UnityEngine;
using System.Collections;

public class AbstractBullet : MonoBehaviour {
    // Stage will be the upgraded(ness) of the item
    private int Stage = 0;

    float lifeSpan = 3.0f;
    public GameObject effect;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
    void Update()  {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0) {
            Explode();
        }
     }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy"){
            Instantiate(effect, collision.transform.position, Quaternion.identity);
            // collision.gameObject.tag = "Untagged";
            //Destroy(gameObject);
            Invoke("PoolingDestroy", 0.1f);
        }
        else { }//TODO what if not an enemy?
    }

    void Explode() {
        Destroy(gameObject);
    }

    void OnEnable() {
        Invoke("PoolingDestroy", lifeSpan);
    }

    void OnDisable() {
        CancelInvoke();
    }

    void PoolingDestroy() {
        gameObject.SetActive(false);
    }
}