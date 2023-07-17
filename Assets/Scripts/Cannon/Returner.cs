using UnityEngine;

public class Returner : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        var isBullet = col.TryGetComponent<IShootable>(out var bullet);

        if (!isBullet) return;

        bullet.Return();
    }
}
