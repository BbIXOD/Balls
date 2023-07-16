using UnityEngine;

public class Pending : MonoBehaviour
{
    public BallTypes type;
    private bool _onQuit;

    private void OnApplicationQuit()
    {
        _onQuit = true;
    }

    private void OnDestroy()
    {
        if (_onQuit) return;
        SingletonsHandler.cannon.pending.Add(type);
    }
}
