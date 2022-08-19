using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script usado para reconhecer a colisão entre o player e um item que pode ser pego
/// </summary>
public class PickUpItems : MonoBehaviour
{
    [SerializeField] protected bool canPick;
    protected GameObject aux;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            canPick = true;
            aux = other.gameObject;
        }
        else
            canPick = false;
    }
}
