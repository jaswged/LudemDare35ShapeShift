using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {
    public GameObject iceCube_prefab;
    public GameObject zippo_prefab;
    public GameObject rock_prefab;
    public GameObject battery_prefab;

    private List<GameObject> pooledIceCubes;
    private List<GameObject> pooledZippos;
    private List<GameObject> pooledRocks;
    private List<GameObject> pooledBatteries;

    public int pooledAmount = 6;

    void Awake() {
        #region Populate Pooling
        pooledIceCubes = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++) {
            GameObject obj = (GameObject)Instantiate(iceCube_prefab);
            obj.SetActive(false);
            pooledIceCubes.Add(obj);
        }

        pooledZippos = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++) {
            GameObject obj = (GameObject)Instantiate(zippo_prefab);
            obj.SetActive(false);
            pooledZippos.Add(obj);
        }

        pooledRocks = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++) {
            GameObject obj = (GameObject)Instantiate(rock_prefab);
            obj.SetActive(false);
            pooledRocks.Add(obj);
        }

        pooledBatteries = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++) {
            GameObject obj = (GameObject)Instantiate(battery_prefab);
            obj.SetActive(false);
            pooledBatteries.Add(obj);
        }
        #endregion
    }

    #region Ice Cubes
    public GameObject getPooledIceCube() {
        for (int i = 0; i < pooledIceCubes.Count; i++) {
            if (pooledIceCubes[i] == null) {
                GameObject obje = (GameObject)Instantiate(iceCube_prefab);
                obje.SetActive(false);
                pooledIceCubes[i] = obje;
                return obje;
            }
            if (!pooledIceCubes[i].activeInHierarchy) {
                return pooledIceCubes[i];
            }
        }
        GameObject iceCube = (GameObject)Instantiate(iceCube_prefab);
        pooledIceCubes.Add(iceCube);
        iceCube.SetActive(false);
        return iceCube;
    }
#endregion
    #region Zippos
    public GameObject GetPooledZippo() {
        for (int i = 0; i < pooledZippos.Count; i++) {
            if (pooledZippos[i] == null) {
                GameObject obje = (GameObject)Instantiate(zippo_prefab);
                obje.SetActive(false);
                pooledZippos[i] = obje;
                return obje;
            }
            if (!pooledZippos[i].activeInHierarchy) {
                return pooledZippos[i];
            }
        }
        GameObject zippo = (GameObject)Instantiate(zippo_prefab);
        pooledZippos.Add(zippo);
        zippo.SetActive(false);
        return zippo;
    }
#endregion
    #region Rocks
    public GameObject getPooledRock() {
        for (int i = 0; i < pooledRocks.Count; i++) {
            if (pooledRocks[i] == null) {
                GameObject obje = (GameObject)Instantiate(rock_prefab);
                obje.SetActive(false);
                pooledRocks[i] = obje;
                return obje;
            }
            if (!pooledRocks[i].activeInHierarchy) {
                return pooledRocks[i];
            }
        }
        GameObject rock = (GameObject)Instantiate(rock_prefab);
        pooledRocks.Add(rock);
        rock.SetActive(false);
        return rock;
    }
    #endregion
    #region Battery
    public GameObject getPooledBattery() {
        for (int i = 0; i < pooledBatteries.Count; i++) {
            if (pooledBatteries[i] == null) {
                GameObject obje = (GameObject)Instantiate(battery_prefab);
                obje.SetActive(false);
                pooledBatteries[i] = obje;
                return obje;
            }
            if (!pooledBatteries[i].activeInHierarchy) {
                return pooledBatteries[i];
            }
        }
        GameObject battery = (GameObject)Instantiate(battery_prefab);
        pooledBatteries.Add(battery);
        battery.SetActive(false);
        return battery;
    }
    #endregion
}