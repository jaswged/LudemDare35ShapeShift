using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    bool isPaused = false;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            Cursor.visible = isPaused;
        }
    }
}
