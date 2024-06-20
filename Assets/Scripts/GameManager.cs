using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// ���� ���� ���¸� ǥ���ϰ�, ���� ������ UI�� �����ϴ� ���� �Ŵ���
// ������ �� �ϳ��� ���� �Ŵ����� ������ �� �ִ�.
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����
    public bool isSongFinished = false; // ���� ����
    public TMP_Text scoreText;
    public TMP_Text CurrentScore;
    public TMP_Text perfect;
    public TMP_Text great;
    public TMP_Text good;
    public TMP_Text bad;
    public Text bestScoreText;
    public GameObject gameresultUI;

    private int score = 0; // ���� ����
    private int perfecttimes = 0;
    private int greattimes = 0;
    private int goodtimes = 0;
    private int badtimes = 0;

    // ���� ���۰� ���ÿ� �̱����� ����
    void Awake()
    {
        // �̱��� ���� instance�� ����ִ°�?
        if (instance == null)
        {
            // instance�� ����ִٸ�(null) �װ��� �ڱ� �ڽ��� �Ҵ�
            instance = this;
        }
        else
        {
            // instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���
            // ���� �ΰ� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�.
            // �̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�
            Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }
    void Update()
    {
        // ���� ���� ���¿��� ������ ������� �� �ְ� �ϴ� ó��
        if (isSongFinished) //&& Input.GetMouseButtonDown(0))
        {
            gameresultUI.SetActive(true);
        }
    }
    // ������ ������Ű�� �޼���
    public void AddScore(int newScore)
    {
        if (isSongFinished)
        {
            //score += newScore;
            //score.text = "Score" + score;
        }
    }
    // �÷��̾� ĳ���Ͱ� ����� ���� ������ �����ϴ� �޼���
    //public void GameOver()
    //{
    //    isSongFinished = true;
    //    gameresultUI.SetActive(true);
    //}

    public void addScore(int noteScore)
    {
        score += noteScore;
        scoreText.text = score.ToString();
        CurrentScore.text = score.ToString(); 
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
        Debug.Log("�� ��ε�.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
