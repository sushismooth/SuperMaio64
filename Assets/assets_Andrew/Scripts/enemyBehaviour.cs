using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class enemyBehaviour : MonoBehaviour
{

	public Transform player;
	public float moveSpeed;
	public float chaseSpeed;
	
	public float detectionDist;
	public float maxChaseDist;
	public bool chasingPlayer;

	public int patrolIndex = 0;
	public Transform[] PatrolPoints;

	
	// Update is called once per frame
	void Update ()
	{
		chasingPlayer = CheckPlayerDetection();
		
		if (!chasingPlayer)
		{
			Patrol();
		}

		if (chasingPlayer)
		{
			Chase();
		}
	}

	bool CheckPlayerDetection()
	{
		Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.yellow);
		RaycastHit hitInfo;
		
		if (!chasingPlayer)
		{
			Physics.Raycast(transform.position, player.transform.position - transform.position, out hitInfo, detectionDist);
			
			if (hitInfo.collider != null)
			{
				if (hitInfo.collider.transform == player)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		if (chasingPlayer)
		{
			Physics.Raycast(transform.position, player.transform.position - transform.position, out hitInfo, maxChaseDist);
			if (hitInfo.collider != null)
			{
				if (hitInfo.collider.transform == player)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		return false;
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

	void Chase()
	{
		Vector3 playerPos = player.transform.position;
		playerPos.y = transform.position.y;
		transform.position = Vector3.MoveTowards(transform.position, playerPos, chaseSpeed * Time.deltaTime);
	}
}
