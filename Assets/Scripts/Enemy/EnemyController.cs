using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    NavMeshAgent nav;
    Transform playerLocation;
    Animator animator;

	// Use this for initialization
	void Awake () {
	    nav = GetComponent<NavMeshAgent>();
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
       // animator = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()  {
        // if alive
        if (Vector3.Distance(transform.position, playerLocation.position) > 5) {
            nav.SetDestination(playerLocation.position);
        }
        else {
            nav.Stop();
        }
        //animator.SetFloat("Speed", Mathf.Abs(nav.velocity.x) + Mathf.Abs(nav.velocity.z));
	}
}