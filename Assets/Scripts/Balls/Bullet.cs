using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _myTransform;
    
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    
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

    private void On2CollisionEnter(Collision collision)
    {
        var forward = _myTransform.up;
        var hit = Physics2D.Raycast(_myTransform.position, forward);
        _myTransform.up = Vector2.Reflect(forward, hit.normal);
        Move();
    }
}
