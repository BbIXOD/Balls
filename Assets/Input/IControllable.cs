using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable
{
    public Vector2 Destination { set; }
    public  bool Pressed { set; }
}
