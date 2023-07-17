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
        if (_cannonTransform.position == transform.position)
            return;

        if (_cannon.changePos)
        {
            _cannon.changePos = false;
            Stop();
            var bTransform = _bullet.transform;
            var ballPos = bTransform.position; 
            ballPos.y = _cannonTransform.position.y;
            bTransform.position = ballPos;
            _cannonTransform.position = ballPos;
            
            _cannon.BulletCount++;
            return;
        }
        
        _bullet.Stop();
        _returning.enabled = true;
        _returning.Destination = _cannonTransform.position;
    }
}
