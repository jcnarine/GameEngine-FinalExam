using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public System.Action destroyed;

    public Rigidbody Rb { get; }
    public float Speed { get; set; }
    public float Rotation { get; set; }
    public float Lives { get; set; }
    public float Scale { get; set; }
    public Vector3 Direction { get; set; }
    }
