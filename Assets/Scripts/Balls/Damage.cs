using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damage; // just in case of bigger damage
    private const string Pending = nameof(Pending);
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.TryGetComponent<IHealth>(out var health)) return;
        
        health.Health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(Pending)) return;
        Destroy(col.gameObject);
    }
}
