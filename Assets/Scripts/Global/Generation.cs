using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generation : MonoBehaviour
{
    private const string LoseScene = nameof(LoseScene);
    
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

    [SerializeField] private float fallPerTurn,
        losePosY;

    private void Awake()
    {
        SingletonsHandler.generator = this;
        _size = brick.transform.lossyScale;
        GenerateBricks();
        startPos.y = endPos.y; //for spawning one row;
    }

    public void GameStep()
    {
        foreach (var falling in bricks)
        {
            falling.position += Vector3.down * fallPerTurn;
            if (falling.position.y <= losePosY)
            {
                SceneManager.LoadScene(LoseScene);
            }
        }
        
        GenerateBricks();
    }

    private void GenerateBricks()
    {
        var curPos = startPos;
        for (; curPos.y <= endPos.y; curPos.y += _size.y)
        {
            for (; curPos.x <= endPos.x; curPos.x += _size.x)
            {
                if (Random.Range(0, Percents) <= brickChance)
                {
                    var instance = Instantiate(brick, curPos, Quaternion.identity);
                    instance.GetComponent<IHealth>().Health = Random.Range(minHealth, maxHealth);
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
