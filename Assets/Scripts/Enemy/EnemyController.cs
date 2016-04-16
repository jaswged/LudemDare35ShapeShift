using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
    NavMeshAgent nav;
    Transform playerLocation;
    Animator controller;

	// Use this for initialization
	void Awake () 
    {
	    nav = GetComponent<NavMeshAgent>();
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        controller = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    // if alive
        nav.SetDestination(playerLocation.position);
        controller.SetFloat("Speed",Mathf.Abs(nav.velocity.x) + Mathf.Abs(nav.velocity.z));
	}
}