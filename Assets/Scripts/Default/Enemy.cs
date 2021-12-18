using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Spaceship
	{

	public float minVelocity;

	public static event Action has_Shot;

	void Awake()
	{
		_Rb = GetComponent<Rigidbody>();

		Direction = new Vector3(0, -1, 0);
		float temp = UnityEngine.Random.Range(minVelocity, _MaxVelocity);
		_Rb.velocity = new Vector3(0.0f, -temp, 0.0f);
		Invoke("enemyFire", 1.0f);
	}


	public void enemyFire() 
		{
		Shoot();
		//Invoking the Observer pattern
		//If the player press the spacebar to shoot, the 'has_Shot' action becomes true and is now invoked
		//This prevents the player from repeatedly playing the audio while shooting.
		has_Shot?.Invoke();
		Invoke("enemyFire", 1.0f);
		}

	public void OnTriggerEnter(Collider other)
		{

		if (other.gameObject.CompareTag("TopBoundary"))
			{ return; }

		if (other.gameObject.CompareTag("Boundary") || (other.gameObject.CompareTag("Player")))
			{
			Destroy(this.gameObject);
			}
		if (other.gameObject.CompareTag("PlayerBullet"))
			{
			if (_Lives == 1) 
			{
				Spawner.totalPoints += 400;
				Spawner._totalEnemiesDestroyed++;
				Destroy(this.gameObject);
			} else {
				_Lives -= 1;
			}
		}

	}

}
