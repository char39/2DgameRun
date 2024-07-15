using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver = false;
    public GameObject obj_gameover;
    public Text text_gameover;
    public Text text_score;
    public int score = 1;

/*
    void Awake()
    {
        if (instance == null)   // 생성된 인스턴스가 없다면
            instance = this;    // 인스턴스를 생성
        else if (instance != this)  // 생성된 인스턴스가 기존에 존재하는 인스턴스와 다를 경우
            Destroy(gameObject);    // 그 인스턴스를 파괴
        //DontDestroyOnLoad(gameObject);  // 씬이 변경되어도 파괴되지 않도록 설정

        SceneManager.sceneLoaded += OnSceneLoaded; // 씬이 로드될 때 호출될 메소드를 등록
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 메모리 누수 방지를 위해 이벤트에서 메소드 제거
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        obj_gameover = GameObject.Find("Canvas_UI").transform.GetChild(1).gameObject;
        text_gameover = GameObject.Find("Canvas_UI").transform.GetChild(1).GetComponent<Text>();
        if (isGameOver)
        {
            obj_gameover.SetActive(true);
        }
        else
        {
            obj_gameover.SetActive(false);
        }
    }

    void Update()
    {
        if (isGameOver)
            obj_gameover.SetActive(true);
        ReStart();
    }
*/
    void Awake()
    {
        if (instance == null)   // 생성된 인스턴스가 없다면
            instance = this;    // 인스턴스를 생성
        else if (instance != this)  // 생성된 인스턴스가 기존에 존재하는 인스턴스와 다를 경우
            Destroy(gameObject);    // 그 인스턴스를 파괴
        //DontDestroyOnLoad(gameObject);  // 씬이 변경되어도 파괴되지 않도록 설정
    }
    void Start()
    {
        obj_gameover = GameObject.Find("Canvas_UI").transform.GetChild(1).gameObject;
        text_gameover = GameObject.Find("Canvas_UI").transform.GetChild(1).GetComponent<Text>();
        text_score = GameObject.Find("Canvas_UI").transform.GetChild(0).GetComponent<Text>();
    }
    void Update()
    {
        if (isGameOver)
        {
            text_score.enabled = false;
            obj_gameover.SetActive(true);
        }
        ReStart();
    }

    private void ReStart()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))  // 게임오버 상태이고 마우스 왼쪽 버튼을 누르면
        {
            isGameOver = false;
            obj_gameover.SetActive(false);
            text_score.enabled = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬을 다시 로드
        }
    }
    public void AddScore(int newScore)
    {
        score += newScore;
        text_score.text = $"Score : <color=#FFAAAA>{score}</color>";
        text_gameover.text = $"Score : <color=#FFAAAA>{score}</color>";
    }
}