
using UnityEngine;

public class HealthHandler : MonoBehaviour, IHealth
{
    private int _health;
    public int Health { get => _health; set => SetHealth(value); }

    private void SetHealth(int value)
    {
        _health = value;
        
        if (_health > 0) return;
        Destroy(gameObject);
    }
}
