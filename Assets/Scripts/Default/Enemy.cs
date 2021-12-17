using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Spaceship
	{

	public float minVelocity;


	void Awake()
	{
		_Rb = GetComponent<Rigidbody>();
		float temp = Random.Range(minVelocity, _MaxVelocity);
		_Rb.velocity = new Vector3(0.0f, -temp, 0.0f);
	}


	public void OnTriggerEnter(Collider other)
		{
		if (other.gameObject.CompareTag("TopBoundary"))
			{ return; }
		if (other.gameObject.CompareTag("Boundary") || (other.gameObject.CompareTag("Player")))
			{
			Spawner._totalEnemiesDestroyed++;
			Destroy(this.gameObject);
			}
		if (other.gameObject.CompareTag("PlayerBullet"))
			{
			if (_Lives == 0) 
			{
				Spawner._totalEnemiesDestroyed++;
				Destroy(this.gameObject);
			} else {
				_Lives -= 1;
			}
		}

	}

}
