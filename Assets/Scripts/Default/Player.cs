using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Player : Spaceship
	{

	public int bounce;
	public TextMeshProUGUI livesText;

	//Implement Observer pattern action
	// Code referenced from Parisa's Lecture 4 Videos: https://drive.google.com/file/d/1mKuH4BzcJgqX2wQFOKWYbX6r7i3cS7mQ/view
	public static event Action has_Shot;


	// Update is called once per frame
	public void Update()
		{

        if (Input.GetKeyDown(KeyCode.Space) && _CanShoot)
			{
			
			Shoot();

			//Invoking the Observer pattern
			//If the player press the spacebar to shoot, the 'has_Shot' action becomes true and is now invoked
			//This prevents the player from repeatedly playing the audio while shooting.
			has_Shot?.Invoke();

			}
		}

	public void FixedUpdate()
		{

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
			_Rb.AddForce(Vector3.up * _Speed, ForceMode.Impulse);
			}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
			_Rb.AddForce(Vector3.down * _Speed, ForceMode.Impulse);
			}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
			_Rb.AddForce(Vector3.left * _Speed, ForceMode.Impulse);
			}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
			_Rb.AddForce(Vector3.right * _Speed, ForceMode.Impulse);
			}

		Vector3 temp = _Rb.velocity;

		if (temp.sqrMagnitude > _SqrMaxVelocity)
			{
			_Rb.velocity = temp.normalized * _MaxVelocity;
			}
		}
	public void OnTriggerEnter(Collider other)
		{
		if (other.gameObject.tag == "Asteroid"|| other.gameObject.tag == "Enemy")
			{
			_Lives -= 1;
			if (_Lives==0) {
				SceneManager.LoadScene("YouLose");
				}
			livesText.text = "Lives: " + _Lives;
			}
		if (other.gameObject.tag == "Boundary" || other.gameObject.tag == "TopBoundary")
			{
			_Rb.AddForce(_Rb.velocity * -1 * bounce, ForceMode.Impulse);
			}
		}
	}
