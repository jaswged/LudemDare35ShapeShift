using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pooling : MonoBehaviour {
#region Variables
    public static Pooling POOL;

    public GameObject healthOrb;
    public GameObject manaOrb;

    public int poolAmount = 1;
    public bool willGrow = true;

    private List<GameObject> healthOrbs;
    private List<GameObject> manaOrbs;
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
        manaOrbs = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++) {
            GameObject obj = (GameObject)Instantiate(manaOrb);
            obj.SetActive(false);
            manaOrbs.Add(obj);
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

    public GameObject GetManaOrb() {
        for (int i = 0; i < manaOrbs.Count; i++) {
            if (!manaOrbs[i].activeInHierarchy) {
                return manaOrbs[i];
            }
        }
        if (willGrow) {
            GameObject obj = (GameObject)Instantiate(manaOrb);
            obj.SetActive(false);

            manaOrbs.Add(obj);
            return obj;
        }
        else {
            return null;
        }    
    }

	void Awake () {POOL = this;}
}