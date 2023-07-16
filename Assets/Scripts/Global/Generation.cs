using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    private const int Percents = 100;

    [SerializeField] private GameObject
        brick,
        ball;
    private IHealth _brickHealth;
    public readonly List<Transform> bricks = new();
    
    [SerializeField]private Vector2
        startPos,
        endPos;
    private Vector2 _size;

    [SerializeField]private int
        minHealth,
        maxHealth,
        healthRoundIncrement, //primitive difficulty progression
        brickChance,
        ballChance;

    [SerializeField] private float fallPerTurn;

    private void Awake()
    {
        SingletonsHandler.generator = this;
        _size = brick.transform.lossyScale;
        _brickHealth = brick.GetComponent<IHealth>();
        GenerateBricks();
        startPos.y = endPos.y; //for spawning one row;
    }

    public void GameStep()
    {
        foreach (var falling in bricks)
        {
            falling.position += Vector3.down * fallPerTurn;
        }
        
        GenerateBricks();
    }

    private void GenerateBricks()
    {
        var curPos = startPos;
        for (; curPos.y <= endPos.x; curPos.y += _size.x)
        {
            for (; curPos.x <= endPos.x; curPos.x += _size.x)
            {
                if (Random.Range(0, Percents) <= brickChance)
                {
                    _brickHealth.Health = Random.Range(minHealth, maxHealth);
                    Instantiate(brick, curPos, Quaternion.identity);
                    continue;
                }

                if (Random.Range(0, Percents) <= ballChance)
                {
                    Instantiate(ball, curPos, Quaternion.identity);
                }
            }
            curPos.x = startPos.x;
        }

        maxHealth += healthRoundIncrement;
    }
}
