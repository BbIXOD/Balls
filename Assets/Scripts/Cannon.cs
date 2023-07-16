using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public List<IShootable> bullets = new();
    public bool AbleToShoot => bulletCount == bullets.Count;
    public int bulletCount;

    public void Shoot()
    {
        if (!AbleToShoot) return;
        
        foreach (var bullet in bullets)
        {
            bullet.Shoot();
        }
    }
}
