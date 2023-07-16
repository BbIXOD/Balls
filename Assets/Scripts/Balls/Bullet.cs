using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _myTransform;
    private Rigidbody2D _rb;
    
    [SerializeField] private float speed;

    private void Start()
    {
        _myTransform = transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetRotation(Quaternion rotation)
    {
        _myTransform.rotation = rotation;
    }

    public void Move()
    {
        _rb.velocity = _myTransform.up * speed;
    }

    public void Stop()
    {
        _rb.velocity = Vector2.zero;
    }
}
