using UnityEngine;
using System.Collections;

public class Bullet_ThermalDet : MonoBehaviour {
    // Stage will be the upgraded(ness) of the item
    private int Stage = 0;

    float lifeSpan = 3.0f;
    public GameObject fireEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()  {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0) {
            Explode();
            }
        }

    void OnCollisionEnter(Collision collision) {
    if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Instantiate(fireEffect, collision.transform.position, Quaternion.identity);
            collision.gameObject.tag = "Untagged";
        }
    }

    void Explode() {
        Destroy(gameObject);
    }
}