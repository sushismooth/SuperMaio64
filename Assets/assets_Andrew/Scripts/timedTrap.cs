using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedTrap : MonoBehaviour
{

	public GameObject trapCollider;
	public float cycleTime;
	private float cycleTimer;
	public float timeActive;
	private float activeTimer;
	private bool isActive = false;

	void Start()
	{
		cycleTimer = cycleTime;
	}
	
	void Update () {
		CycleTimer();
		if (isActive)
		{
			ActiveTimer();
		}
	}

	void CycleTimer()
	{
		cycleTimer += Time.deltaTime;
		if (cycleTimer >= cycleTime)
		{
			Activate();
		}
	}

	void Activate()
	{
		cycleTimer = 0;
		activeTimer = 0;
		isActive = true;
		trapCollider.SetActive(true);
		
	}
	
	void ActiveTimer()
	{
		activeTimer += Time.deltaTime;
		if (activeTimer >= timeActive)
		{
			isActive = false;
			trapCollider.SetActive(false);
		}
	}
}
