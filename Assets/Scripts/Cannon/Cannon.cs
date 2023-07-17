using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class Cannon : MonoBehaviour
{
    private Transform _myTransform;
    
    [NonSerialized]public  readonly List<IShootable> bullets = new();
    [SerializeField]private int bulletDelay;
    [SerializeField]private TMP_Text text;
    private Generation _generator;
    public bool AbleToShoot => BulletCount == bullets.Count;
    public bool shooting;
    public bool changePos;
    public int BulletCount { get => _bulletCount; set => SetCount(value); }
    private int _bulletCount;

    [NonSerialized]public readonly List<BallTypes> pending = new();
    private const string Path = "Balls/";

    private void Awake()
    {
        SingletonsHandler.cannon = this;
        _myTransform = transform;
        _generator = FindObjectOfType<Generation>();
    }

    public async void Shoot() //i know about coroutines, but they are slow
    {
        if (!AbleToShoot) return;

        changePos = true;
        shooting = true;
        foreach (var bullet in bullets)
        {
            bullet.Shoot();
            await Task.Delay(bulletDelay);
        }

        shooting = false;
    }

    public void ReturnAll()
    {
        foreach (var bullet in bullets)
        {
            bullet.Return();
        }
        
    }

    private void SetCount(int value)
    {
        var wasAbleToShoot = AbleToShoot;
        _bulletCount = value;
        text.text = "x" + Convert.ToString(value);
        
        if (!AbleToShoot || wasAbleToShoot) return;
        foreach (var ball in pending)
        {
            Instantiate(Resources.Load(Path + ball), _myTransform.position, _myTransform.rotation);
        }
        pending.Clear();
        _generator.GameStep();
        
    }
}
