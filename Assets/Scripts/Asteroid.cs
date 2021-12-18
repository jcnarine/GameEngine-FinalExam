using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Projectile
{

	private Rigidbody _Rb;
	private float _Speed, _Rotation, _Lives, _Scale;
	private Vector3 _Direction;

	public float GetSpeed()
		{ return _Speed; }

	public void SetSpeed(float value)
		{ _Speed = value; }

	public float GetRotation()
		{ return _Rotation; }

	public void SetRotation(float value)
		{ _Rotation = value; }

	public float GetLives()
		{ return _Lives; }

	public void SetLives(float value)
		{ _Lives = value; }

	public float GetScale()
		{ return _Scale; }

	public void SetScale(float value)
		{ _Scale = value; }

	public Vector3 GetDirection()
		{ return _Direction; }

	public void SetDirection(Vector3 value)
		{ _Direction = value; }

	// Start is called before the first frame update
	public void Start()
    {
		transform.localScale = new Vector3(GetScale(), GetScale(), GetScale());
		_Rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    public void Update()
    {
		Move();
	}

	public void Move()
		{
		_Rb.MovePosition(transform.position + (_Direction * _Speed * Time.deltaTime));
		transform.Rotate(transform.rotation.x + _Rotation, transform.rotation.y, transform.rotation.z);
		}


	public void OnTriggerEnter(Collider other)
		{

		if (other.gameObject.CompareTag("Asteroid") || other.gameObject.CompareTag("TopBoundary")) { return; }

		_Lives--;

		if (other.gameObject.CompareTag("PlayerBullet") && _Lives <= 0)
			{
			Spawner._totalEnemiesDestroyed++;
			Spawner.totalPoints += 200;
			Destroy(this.gameObject);
			}

		if (_Lives <= 0)
			{
			Destroy(this.gameObject);
			}
		}
	}
