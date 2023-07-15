using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField]private GameObject brick;
    private IHealth _brickHealth;
    
    [SerializeField]private Vector2
        startPos,
        endPos;
    private Vector2 _size;

    [SerializeField]private int
        minHealth,
        maxHealth,
        healthRoundIncrement; //primitive difficulty progression

    private void Awake()
    {
        _size = brick.transform.lossyScale;
        _brickHealth = brick.GetComponent<IHealth>();
    }

    private void InitialGenerateBricks()
    {
        var curPos = startPos;
        for (; curPos.y < endPos.x; curPos.y += _size.x)
        {
            for (; curPos.x < endPos.x; curPos.x += _size.x)
            {
                _brickHealth.Health = Random.Range(minHealth, maxHealth);
                Instantiate(brick, curPos, Quaternion.identity);
            }
            curPos.x = startPos.x;
        }
    }
}
