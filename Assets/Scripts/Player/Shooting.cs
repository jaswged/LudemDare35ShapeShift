using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ShapeShift;

public class Shooting : MonoBehaviour {
    Camera cam;
    public GameObject manager;
    PoolManager poolManager;
    public int CurrentPower = 1;

    public float arrowRange = 100f;
    public float bulletImpulse = 15f;

    public float cooldown = 0.3f;
    float cooldownRemaining = 0;

    void Awake() {
        cam = Camera.main;
        poolManager = manager.GetComponent<PoolManager>();
    }

    // Update is called once per frame
    void Update () {
        cooldownRemaining -= Time.deltaTime;
	    if(Input.GetButtonDown("Fire1") && cooldownRemaining <= 0)  {
            cooldownRemaining = cooldown;

            GameObject mageBlast = null;

            switch(CurrentPower) {
                case Constants.EARTH:
                    print("Earth yo");
                    mageBlast = poolManager.getPooledRock();
                    break;
                case Constants.FIRE:
                    print("FIre yo");
                    mageBlast = poolManager.GetPooledZippo();
                    break;
                case Constants.LIGHTNING:
                    print("LIGHTNING yo");
                    mageBlast = poolManager.getPooledBattery();
                    break;
                case Constants.WATER:
                    print("Water yo");
                    mageBlast = poolManager.getPooledIceCube();
                    break;
            }

            mageBlast.transform.position = transform.position;
            mageBlast.transform.rotation = transform.rotation;
            mageBlast.SetActive(true);

            //(GameObject)Instantiate(spell_prefab, cam.transform.position + cam.transform.forward, transform.rotation);
            mageBlast.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);
         }
  #region Arrow Simulation
       /* else if (Input.GetButtonDown("Fire2") && cooldownRemaining <= 0)
            {
            cooldownRemaining = cooldown;

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo, arrowRange))  {
                Vector3 hitPoint = hitInfo.point;
                GameObject go = hitInfo.collider.gameObject;

                HasHealth health = go.GetComponent<HasHealth>();
                if(health!=null) {
                    health.RecieveDamage(damage);
                 }

                // Create hit animation
                if (arrowPrefab != null)  {
                    //Instantiate(arrowPrefab, hitPoint, Quaternion.identity);
                    Instantiate(arrowPrefab, hitPoint, Quaternion.Euler(hitInfo.normal));
                    
                  }
              }
         }*/
#endregion
	}
}