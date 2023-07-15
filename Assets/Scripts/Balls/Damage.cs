using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damage; // just in case of bigger damage

    private void OnCollisionEnter(Collision collision)
    {
        var hasHealth = collision.gameObject.TryGetComponent<IHealth>(out var health);
        
        if (!hasHealth)
        {
            return;
        }
        health.Health -= damage;
    }
}
