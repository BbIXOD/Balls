using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Transform _myTransform;

    private void Awake()
    {
        _myTransform = transform;
    }

    public void Aim(Vector2 destination)
    {
        _myTransform.forward = (Vector3)destination - _myTransform.forward;
    }
}
