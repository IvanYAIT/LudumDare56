using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	public int Value;
	public Lock locker;

	private void Start()
	{
		locker = GetComponentInParent<Lock>();
	}
	public void OnButtonB()
	{
		locker.EnterNumber(this);
	}
}
