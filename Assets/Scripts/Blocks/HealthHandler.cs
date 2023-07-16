
using System;
using UnityEngine;

public class HealthHandler : MonoBehaviour, IHealth
{
    private int _health;
    public int Health { get => _health; set => SetHealth(value); }
    
    [SerializeField]private TMPro.TMP_Text text;
    [SerializeField]private SpriteRenderer sRenderer;

    private void SetHealth(int value)
    {
        _health = value;
        text.text = Convert.ToString(value);
        var fValue = (float)value;
        sRenderer.color = new Color(1 / fValue, 1 / (fValue % 5), (1 / value % 10));

        if (_health > 0) return;
        Destroy(gameObject);
    }
}
