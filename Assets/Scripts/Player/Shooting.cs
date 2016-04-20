using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ShapeShift;
using System;

public class Shooting : MonoBehaviour {
    Camera cam;
    public GameObject manager;
    PoolManager poolManager;
    public int CurrentPower = 1;

    public float bulletImpulse = 15f;

    public float cooldown = 0.5f;
    float cooldownRemaining = 0;

    public float attackManaCost = 15;
    public float specialManaCost = 30;

    public Texture fireTexture;
    public Texture waterTexture;
    public Texture lightningTexture;
    public Texture earthTexture;

    void Awake() {
        cam = Camera.main;
        poolManager = manager.GetComponent<PoolManager>();
    }

    // Update is called once per frame
    void Update() {
        cooldownRemaining -= Time.deltaTime;

        checkStateChanged();

        if (cooldownRemaining >= 0 || PlayersHealth.playerHealth.isDead) {
            return;
        }

        GameObject mageBlast = null;
        if (Input.GetButtonDown("Fire1") && cooldownRemaining <= 0) {
            //&& PlayersHealth.playerHealth.mana > attackManaCost)  {
            cooldownRemaining = cooldown;

          switch (CurrentPower) {
            case Constants.EARTH:
                mageBlast = poolManager.getPooledRock();
                break;
            case Constants.FIRE:
                mageBlast = poolManager.GetPooledZippo();
                break;
            case Constants.LIGHTNING:
                mageBlast = poolManager.getPooledBattery();
                break;
            case Constants.WATER:
                mageBlast = poolManager.getPooledIceCube();
                break;
          }

        mageBlast.SetActive(true);
        mageBlast.transform.position = cam.transform.position;
        mageBlast.transform.rotation = cam.transform.rotation;

        //(GameObject)Instantiate(spell_prefab, cam.transform.position + cam.transform.forward, transform.rotation);
        mageBlast.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);
    }

        #region Harder Attack
        if (Input.GetButtonDown("Fire2") && cooldownRemaining <= 0 && PlayersHealth.playerHealth.mana > specialManaCost) {
        print("Harder attack");
        cooldownRemaining = cooldown;

        /*      switch (CurrentPower) {
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
                }*/
        }// End hard attack
        #endregion
    }//End of Update

    private void checkStateChanged() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            CurrentPower = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            CurrentPower = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            CurrentPower = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            CurrentPower = 4;
        }
    }

    void OnGUI() {
        switch (CurrentPower) {
        case Constants.EARTH:
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), earthTexture);
            break;
        case Constants.FIRE:
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fireTexture);
            break;
        case Constants.LIGHTNING:
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lightningTexture);
            break;
        case Constants.WATER:
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), waterTexture);
            break;
        }
    }
}