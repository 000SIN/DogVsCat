using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject retryBtn;
    // Start is called before the first frame update

    public RectTransform levelFront;
    public Text levelTxt;

    int level = 0;
    int score = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        Application.targetFrameRate = 60; //모든 컴퓨터의 프레임 수를 똑같이 맞춰주기
        Time.timeScale = 1.0f;
    }
    
    void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(normalCat);//normalCat 프리팹의 **복제본(인스턴스)를 씬에 생성.
    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore()
    {
        score++; //= (score += 1)
        level = score / 5;
        levelTxt.text = level.ToString();
        levelFront.localScale = new Vector3((score - level * 5) / 5.0f, 1f, 1f);
    }
}
