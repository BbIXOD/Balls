using System;
using UnityEngine;

public class Shootable : MonoBehaviour, IShootable
{
    private Bullet _bullet;
    private Cannon _cannon;
    private Transform _cannonTransform;

    private void Awake()
    {
        _bullet = GetComponent<Bullet>();
        _cannon = FindObjectOfType<Cannon>();
        _cannonTransform = _cannon.transform;
        _cannon.bullets.Add(this);
        _cannon.bulletCount++;
    }

    public void Shoot()
    {
        _cannon.bulletCount--;
        _bullet.SetRotation(_cannonTransform.rotation);
        _bullet.Move();
    }
}
