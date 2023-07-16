using System;
using UnityEngine;

public class Returner : MonoBehaviour
{
    private Cannon _cannon;
    private const string BallTag = "Ball";
    private float _returnY;
    

    private void Awake()
    {
        _cannon = FindObjectOfType<Cannon>();
        _returnY = _cannon.transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var isBullet = col.TryGetComponent<IShootable>(out var bullet);

        if (!isBullet) return;

        _cannon.BulletCount++;

        if (_cannon.BulletCount == 1)
        {
            var bulletTransform = col.transform;
            
            bullet.Stop();
            var ballPos = bulletTransform.position; 
            ballPos.y = _returnY;
            bulletTransform.position = ballPos;
            _cannon.transform.position = ballPos;
            return;
        }
        
        bullet.Return();
    }
}
