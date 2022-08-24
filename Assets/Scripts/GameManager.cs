using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Pun;
using Cinemachine;
using UnityEngine.UI;
/// <summary>
/// Script usado para gerenciar o jogo
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private HordeManager hordeManager;
    [SerializeField] private HudManager hudManager;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerCam playerCam;

    [SerializeField] private CinemachineVirtualCamera cam;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }
    private void Start()
    {
        StartGame();
    }
    /// <summary>
    /// Usado para iniciar o game
    /// </summary>
    public void StartGame()
    {
        Time.timeScale = 1f;
        //SpawnPlayer();
        hordeManager.StartRound();
    }
    /// <summary>
    /// Adiciona um player na cena
    /// </summary>
    //public void SpawnPlayer()
    //{
    //    GameObject p1 = PhotonNetwork.Instantiate(player.name, this.transform.position, Quaternion.identity);
    //    p1.SetActive(true);
    //    PlayerFinder.instance.AddPlayer(p1);
    //    playerCam.SetCamera(p1.transform);
    //}
    /// <summary>
    /// Script usado para indicar o fim do jogo
    /// </summary>
    /// <param name="victory">se o player venceu ou não</param>
    public void GameOver(bool victory)
    {
        scoreManager.SaveScore();
        Time.timeScale = 0f;
        gameOverScreen.gameObject.SetActive(true);
        gameOverScreen.SetGameOverScreen(victory, scoreManager.Score, scoreManager.Highscore);
    }
}
