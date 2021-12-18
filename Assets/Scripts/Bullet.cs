using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
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
		_Rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    public void Update()
    {
		Move();
	}

	public void Move()
		{
		_Rb.AddForce(_Direction * _Speed, ForceMode.Impulse);
		}


	public void OnTriggerEnter(Collider other)
		{

		if (this.gameObject.tag == "EnemyBullet" && other.gameObject.CompareTag("Enemy")) 
			{
			return;
			}

		if (this.gameObject.tag == "PlayerBullet" && other.gameObject.CompareTag("Player"))
			{
			return;
			}

		this.destroyed.Invoke();
		Destroy(this.gameObject);
		}
	}
