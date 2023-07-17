using System;
using UnityEngine;
using Random = System.Random;

public class HealthHandler : MonoBehaviour, IHealth
{
    private int _health;
    public int Health { get => _health; set => SetHealth(value); }
    
    [SerializeField]private TMPro.TMP_Text text;
    [SerializeField]private SpriteRenderer sRenderer;
    

    private void SetHealth(int value)
    {
        _health = value;
        
        if (_health <= 0)
        {
            Destroy(gameObject);
            return;
        }

        var random = new Random(_health); // this is system random to get same colours from same health

        text.text = Convert.ToString(value);
        var fValue = (float)value;
        sRenderer.color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
    }
}
