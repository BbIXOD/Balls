using System;
using UnityEngine;

public class Fallable : MonoBehaviour
{
    private Generation _generation;
    private void Awake()
    {
        _generation = SingletonsHandler.generator; 
        _generation.bricks.Add(transform);
    }

    private void OnDestroy()
    {
        _generation.bricks.Remove(transform);
    }
}
