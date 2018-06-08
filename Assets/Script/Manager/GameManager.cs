using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    GameStart,
    Gaming,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public Transform startPosition;
    public event EventHandler OnGameStart;
    public event EventHandler OnGameOver;
    public event EventHandler OnPickItem;
    public static GameState curState;
    private static GameManager instance;
    private Player player;
    public static GameManager GetInstance()
    {
        if (instance == null)
            Debug.LogError("GameManager未初始化");
        return instance;
    }

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        Debug.Log("搜索玩家对象");
    }

    public void Init()
    {
        curState = GameState.GameStart;
        instance = this;
    }

    public void StartGame(object sender, EventArgs e)
    {
        StartCoroutine(GameStartProcess(sender, e));
    }

    public void EndGame(object sender, EventArgs e)
    {
        StartCoroutine(GameOverProcess(sender, e));
    }

    public void PickItem(object sender, PickUpEventArgs e)
    {
        if (OnPickItem != null)
            OnPickItem(sender,e);
    }

    public void ResetPlayer()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
        player.transform.position = startPosition.position;
        var rb2d = player.GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        rb2d.velocity = Vector3.zero;
    }

    public void RestartGame()
    {
        UIManager.GetInstance().InvokeLoadingPanel(() =>
        {
            UIManager.GetInstance().ClosePanel("GameOverPanel", UITweenType.Scale);
            UIManager.GetInstance().ClosePanel("PausePanel", UITweenType.Scale);
            UIManager.GetInstance().ClosePanel("GamingPanel", UITweenType.Fade);
            curState = GameState.GameStart;
            TerranManager.GetInstance().Init();
            ResetPlayer();
            Time.timeScale = 1;
            StartCoroutine(GameRestartProcess());
        });
    }

    private IEnumerator GameStartProcess(object sender, EventArgs e)
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("游戏开始");
        curState = GameState.Gaming;
        if (OnGameStart != null)
            OnGameStart(sender, e);
    }

    private IEnumerator GameOverProcess(object sender, EventArgs e)
    {
        curState = GameState.GameOver;
        if (OnGameOver != null)
            OnGameOver(sender, e);
        yield return new WaitForSeconds(2f);
        ResetPlayer();
    }

    private IEnumerator GameRestartProcess()
    {
        yield return new WaitForSeconds(0.5f);
        StartGame(null, EventArgs.Empty);
    }

}
