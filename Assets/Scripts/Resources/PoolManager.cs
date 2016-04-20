using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {
    public GameObject iceCube_prefab;
    public GameObject zippo_prefab;
    public GameObject rock_prefab;
    public GameObject battery_prefab;

    public List<GameObject> pooledIceCubes;
    public List<GameObject> pooledZippos;
    public List<GameObject> pooledRocks;
    public List<GameObject> pooledBatteries;

    public int pooledAmount = 6;

    void Awake() {
        #region Populate Pooling
        pooledIceCubes = new List<GameObject>();
        GameObject cube = (GameObject)Instantiate(iceCube_prefab);
        cube.SetActive(false);
        pooledIceCubes.Add(cube);

        pooledZippos = new List<GameObject>();
        GameObject zippo = (GameObject)Instantiate(zippo_prefab);
        zippo.SetActive(false);
        pooledZippos.Add(zippo);

        pooledRocks = new List<GameObject>();
        GameObject rock = (GameObject)Instantiate(rock_prefab);
        rock.SetActive(false);
        pooledRocks.Add(rock);

        pooledBatteries = new List<GameObject>();
        GameObject battery = (GameObject)Instantiate(battery_prefab);
        battery.SetActive(false);
        pooledBatteries.Add(battery);
        #endregion
    }

    #region Ice Cubes
    public GameObject getPooledIceCube() {
        GameObject ice = (GameObject)Instantiate(iceCube_prefab);
        ice.SetActive(false);
        return ice;
        /*print("Get ice cube");
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
        return iceCube;*/
    }
    #endregion
    #region Zippos
    public GameObject GetPooledZippo() {
        GameObject zip = (GameObject)Instantiate(zippo_prefab);
        zip.SetActive(false);
        return zip;
        /* print("Get Zippo");
         foreach (GameObject zip in pooledZippos) { 
             if (!zip.activeInHierarchy) {
                 print("Return a zippo that was not active in Hierarchy");
                 return zip;
             }
         }
         Debug.LogError("Returning a new zippo");
         GameObject zippo = (GameObject)Instantiate(zippo_prefab);
         pooledZippos.Add(zippo);
         zippo.SetActive(true);
         return zippo;*/

        /*  for (int i = 0; i < pooledZippos.Count; i++) {
              if (pooledZippos[i] == null) {
                  print("Zippo was null\n");
                  GameObject obje = (GameObject)Instantiate(zippo_prefab);
                  obje.SetActive(false);
                  pooledZippos[i] = obje;
                  return obje;
              }
              if (!pooledZippos[i].activeInHierarchy) {
                  print("Zippo was just sleeping\n");
                  return pooledZippos[i];
              }
          }
          print("Create and add another zippo to the list\n");
          GameObject zippo = (GameObject)Instantiate(zippo_prefab);
          pooledZippos.Add(zippo);
          zippo.SetActive(false);
          return zippo;*/
    }
#endregion
    #region Rocks
    public GameObject getPooledRock() {
        /*for (int i = 0; i < pooledRocks.Count; i++) {
            if (pooledRocks[i] == null) {
                GameObject obje = (GameObject)Instantiate(rock_prefab);
                obje.SetActive(false);
                pooledRocks[i] = obje;
                return obje;
            }
            if (!pooledRocks[i].activeInHierarchy) {
                return pooledRocks[i];
            }
        }*/
        GameObject rock = (GameObject)Instantiate(rock_prefab);
        rock.SetActive(false);
        return rock;
    }
    #endregion
    #region Battery
    public GameObject getPooledBattery() {
        /*for (int i = 0; i < pooledBatteries.Count; i++) {
            print("in for loop batter at " + i);
            if (!pooledBatteries[i].activeInHierarchy) {
                print("Returning battery at " + i);
                return pooledBatteries[i];
            }
        }
        print("Should be creating a new battery");
        GameObject battery = (GameObject)Instantiate(battery_prefab);
        battery.SetActive(false);
        pooledBatteries.Add(battery);
        return battery;*/
        GameObject bat = (GameObject)Instantiate(battery_prefab);
        bat.SetActive(false);
        return bat;
    }
    #endregion
}