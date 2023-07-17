using UnityEngine;

public class HideObject : MonoBehaviour
{
    [SerializeField]private GameObject _object;
    private Cannon _cannon;

    private void Start()
    {
        _cannon = SingletonsHandler.cannon;
    }

    private void Update()
    {
        _object.SetActive(!_cannon.AbleToShoot && !_cannon.shooting);
    }
}
