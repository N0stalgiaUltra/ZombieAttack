using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Interface usada para controlar a vida
/// </summary>
public interface IHealth
{
    public int health { get;}
    public void Damage(int value);
}
