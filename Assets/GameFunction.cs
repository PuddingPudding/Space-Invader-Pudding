using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFunction : MonoBehaviour
{
    public GameObject Enemy;
    public float spawningTime = 0;

    public Text ScoreText;
    public int Score = 0;
    public static GameFunction Instance;

    public GameObject GameTitle; //宣告GameTitle物件
    public GameObject GameOverTitle; //宣告GameOverTitle物件
    public GameObject PlayButton; //宣告PlayButton物件
    public bool IsPlaying = false; // 宣告IsPlaying 的布林資料，並設定初始值false

    public GameObject RestartButton; //宣告RestartButton的物件
    public GameObject QuitButton; //宣告QuitButton的物件

    // Use this for initialization
    void Start()
    {
        Instance = this;
        this.GameOverTitle.SetActive(false);

        RestartButton.SetActive(false); //RestartButton設定成不顯示
        QuitButton.SetActive(false); //QuitButton同理
    }

    // Update is called once per frame
    void Update()
    {
        this.spawningTime += Time.deltaTime;
        if (this.spawningTime >= 0.5f && this.IsPlaying == true)
        {
            Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), 6f, 0);
            Instantiate(this.Enemy, pos, transform.rotation); //產生敵人
            this.spawningTime = 0f; //時間歸零

            this.Score += 2; //每產生一個敵人玩家便得2分
            this.ScoreText.text = "Score: " + Score;
        }
    }

    public void GameStart()
    {
        this.IsPlaying = true; //設定IsPlaying為true，代表遊戲正在進行中
        GameTitle.SetActive(false); //不顯示GameTitle
        PlayButton.SetActive(false); //不顯示PlayButton
    }

    public void GameOver() //GameOver的Function
    {
        IsPlaying = false; //IsPlaying設定成false，停止產生外星人
        GameOverTitle.SetActive(true); //GameOverTitle設定為ture
        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
    }

    public void ResetGame() //RestartButton的功能
    {
        SceneManager.LoadScene(0);//讀取關卡(已讀取的關卡)
    }

    public void QuitGame() //QuitButton的功能
    {
        Application.Quit(); //離開應用程式
    }

    public void AddScore()
    {
        this.Score += 10;
        this.ScoreText.text = "Score: " + Score;
    }

    public void MinusScore()
    {
        this.Score -= 25;

        if (this.Score < 0) //避免把玩家的分數扣到負數
        {
            this.Score = 0;
        }

        this.ScoreText.text = "Score: " + Score;
    }
}
