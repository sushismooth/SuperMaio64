using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour {

	public float moveSpeed;
	public int patrolIndex = 0;
	public Transform[] PatrolPoints;
	
	// Update is called once per frame
	void Update () {
		Patrol();
	}
	
	void Patrol()
	{
		transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[patrolIndex].position, moveSpeed * Time.deltaTime);
		transform.LookAt(PatrolPoints[patrolIndex]);

		if (Vector3.Distance(transform.position, PatrolPoints[patrolIndex].position) < 0.5)
		{
			patrolIndex++;
			if (patrolIndex >= PatrolPoints.Length)
			{
				patrolIndex = 0;
			}
		}
	}
}
