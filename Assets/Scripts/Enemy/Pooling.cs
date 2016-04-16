using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pooling : MonoBehaviour {
#region Variables
    public static Pooling POOL;

    public GameObject healthOrb;
    public GameObject energyOrb;

    public int poolAmount = 1;
    public bool willGrow = true;

    private List<GameObject> healthOrbs;
    private List<GameObject> energyOrbs;
#endregion

    void Start() {
#region Health Orbs
        healthOrbs = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++) {
            GameObject obj = (GameObject) Instantiate(healthOrb);
            obj.SetActive(false);
            healthOrbs.Add(obj);
        }
#endregion
#region Energy Orbs
        energyOrbs = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++) {
            GameObject obj = (GameObject)Instantiate(energyOrb);
            obj.SetActive(false);
            energyOrbs.Add(obj);
        }
#endregion
    }

    public GameObject GetHealthOrb() {
        for (int i = 0; i < healthOrbs.Count; i++) {
            if (!healthOrbs[i].activeInHierarchy) {
                return healthOrbs[i];
            }
        }
        if (willGrow) {
            GameObject obj = (GameObject)Instantiate(healthOrb);
            obj.SetActive(false);
            healthOrbs.Add(obj);
            return obj;
        }
        else {
            return null;
        }  
    }

    public GameObject GetEnergyOrb() {
        for (int i = 0; i < energyOrbs.Count; i++) {
            if (!energyOrbs[i].activeInHierarchy) {
                return energyOrbs[i];
            }
        }
        if (willGrow) {
            GameObject obj = (GameObject)Instantiate(energyOrb);
            obj.SetActive(false);

            energyOrbs.Add(obj);
            return obj;
        }
        else {
            return null;
        }    
    }

	void Awake () {POOL = this;}
}