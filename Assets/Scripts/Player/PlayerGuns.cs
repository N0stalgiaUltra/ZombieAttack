//using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script que controla as armas do player
/// </summary>
public class PlayerGuns : PickUpItems
{
    [SerializeField] private GunLogic playerGun;
    [SerializeField] private Transform playerArm;
    [SerializeField] private PlayerAnimation playerAnim;
    //public PhotonView view;

    private bool haveGun;
    private void Start()
    {
        InputManager.playerShooted += PlayerShoot; 
        InputManager.playerPicked += PickUpGun;
    }
    private void FixedUpdate()
    {
        if (playerGun != null)
        {
            playerGun.transform.position = playerArm.position;
            playerGun.transform.rotation = playerArm.rotation;
        }
    }

    /// <summary>
    /// Ação para fazer o player atirar.
    /// </summary>
    private void PlayerShoot()
    {
        //OBS: esse trecho pode parecer redundante, mas ele apenas verifica se o player tem uma arma para atirar, se não, não faz nada.
        
        if(/*view.IsMine &&*/ playerGun != null)
        {
            playerGun.Shoot();
        }

    }

    /// <summary>
    /// Usado para fazer o player pegar uma arma no chão ou substituir a arma atual (Chamado ao clicar no botão de "PICK")
    /// </summary>
    private void PickUpGun()
    {
        //if (view.IsMine && canPick)
        //{
        //    if (playerGun != null)//troca a arma
        //    {
        //        playerGun.transform.SetParent(null);
        //        Destroy(playerGun.gameObject);
        //        //playerGun = null;
        //    }
            
        //    playerGun = aux.GetComponent<GunLogic>();

        //    playerGun.transform.position = playerArm.position;
        //    playerGun.transform.rotation = playerArm.rotation;
        //    playerGun.transform.parent = playerArm;

        //    aux = null;
        //    canPick = false;
        //    playerGun.DisableCollider();
        //}

        if (playerGun != null && canPick)//troca a arma
        {
            playerGun.transform.SetParent(null);
            Destroy(playerGun.gameObject);
            //playerGun = null;
        }

        playerGun = aux.GetComponent<GunLogic>();

        playerGun.transform.position = playerArm.position;
        playerGun.transform.rotation = playerArm.rotation;
        playerGun.transform.parent = playerArm;

        aux = null;
        canPick = false;
        playerGun.DisableCollider();
        //else return;
    }

    private void OnDisable()
    {
        InputManager.playerShooted -= PlayerShoot;
        InputManager.playerPicked -= PickUpGun;
    }
}
