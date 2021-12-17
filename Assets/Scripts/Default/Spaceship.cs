using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public Bullet _BulletPrefab;
    public Transform _BulletTransform;

    protected Rigidbody _Rb;

    public float _Speed, _MaxVelocity;
    public int _Lives; 

    protected float _SqrMaxVelocity;
    protected bool _CanShoot = true;

    // Start is called before the first frame update
    protected void Start()
    {
        _Rb = GetComponent<Rigidbody>();
        _SqrMaxVelocity = _MaxVelocity * _MaxVelocity;
    }

    protected void Shoot()
        {
        if (!(_CanShoot = true))
            {
            return;
            }
        Quaternion quat = Quaternion.Euler(0, 90, 90);
        Bullet projectile = Instantiate(_BulletPrefab, _BulletTransform.transform.position, quat);
        projectile.SetDirection(new Vector3(0, 1, 0));
        projectile.SetSpeed(13);
        projectile.destroyed += LaserDestroyed;
        _CanShoot = false;
        }

    protected void LaserDestroyed()
        {
        _CanShoot = true;
        }

    }
