using System;
using UnityEngine;

public class Shootable : MonoBehaviour, IShootable
{
    private Bullet _bullet;
    private Returning _returning;
    private Cannon _cannon;
    private Transform _cannonTransform;

    private void Start()
    {
        _bullet = GetComponent<Bullet>();
        _returning = GetComponent<Returning>();
        _cannon = SingletonsHandler.cannon;
        _cannonTransform = _cannon.transform;

        _returning.enabled = false;
        _cannon.BulletCount++;
        _cannon.bullets.Add(this);
    }

    public void Shoot()
    {
        _cannon.BulletCount--;
        _bullet.SetRotation(_cannonTransform.rotation);
        _bullet.Move();
    }

    public void Stop()
    {
        _bullet.Stop();
    }

    public void Return()
    {
        _bullet.Stop();
        _returning.enabled = true;
        _returning.Destination = _cannonTransform.position;
    }
}
