using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// 게임 오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있다.
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤을 할당할 전역 변수
    public bool isSongFinished = false; // 음악 종료
    public TMP_Text scoreText;
    public TMP_Text perfect;
    public TMP_Text great;
    public TMP_Text good;
    public TMP_Text bad;
    public Text bestScoreText;
    public GameObject gameresultUI;

    private int score = 0; // 게임 점수
    private int perfecttimes = 0;
    private int greattimes = 0;
    private int goodtimes = 0;
    private int badtimes = 0;

    // 게임 시작과 동시에 싱글톤을 구성
    void Awake()
    {
        // 싱글톤 변수 instance가 비어있는가?
        if (instance == null)
        {
            // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            instance = this;
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우
            // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }
    void Update()
    {
        // 게임 오버 상태에서 게임을 재시작할 수 있게 하는 처리
        if (isSongFinished) //&& Input.GetMouseButtonDown(0))
        {
            gameresultUI.SetActive(true);
        }
    }
    // 점수를 증가시키는 메서드
    public void AddScore(int newScore)
    {
        if (isSongFinished)
        {
            //score += newScore;
            //score.text = "Score" + score;
        }
    }
    // 플레이어 캐릭터가 사망시 게임 오버를 실행하는 메서드
    //public void GameOver()
    //{
    //    isSongFinished = true;
    //    gameresultUI.SetActive(true);
    //}

    public void addScore(int noteScore)
    {
        score += noteScore;
        scoreText.text = score.ToString();
    }

    public void noteResult(int judgement)
    {
        if (judgement == 0)
        {
            perfecttimes += 1;
            perfect.text = perfecttimes.ToString();
        }

        else if (judgement == 1)
        {
            greattimes += 1;
            great.text = greattimes.ToString();
        }

        else if (judgement == 2)
        {
            goodtimes += 1;
            good.text = goodtimes.ToString();
        }

        else
        {
            badtimes += 1;
            bad.text = badtimes.ToString();
        }
            
    }

    public void OnClickRestartButton()
    {
        Debug.Log("씬 재로드.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
