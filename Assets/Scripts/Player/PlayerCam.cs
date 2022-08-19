using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// Usado para fazer a camera seguir o player
/// </summary>
public class PlayerCam : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;

    public void SetCamera(Transform player)
    {
        cam.Follow = player;
        cam.LookAt = player;
    }
}
