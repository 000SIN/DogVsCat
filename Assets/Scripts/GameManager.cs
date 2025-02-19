using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;
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

        level = 0; //level 초기화 추가
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
        Debug.Log("현재 Level: " + level);
        Instantiate(normalCat);//normalCat 프리팹의 **복제본(인스턴스)를 씬에 생성.
                               //예를 들어 p가 0, 1, 2일 때는 아무것도 생성되지 않음(30 % 확률로 고양이 안 나옴).
                               //즉, 랜덤 값에 따라 고양이가 아예 안 나올 수도 있는 상황이 됨.
                               //이를 방지하기 위해 무조건 한 마리는 생성되도록 코드가 추가된 것. 
        //Iv.1 20% 확률로 고양이를 더 생성
        if (level == 1)
        {
            int p = Random.Range(0, 10); // p라는 값을 0~9 사이의 숫자 중에서 랜덤으로 생성
            if (p < 2) Instantiate(normalCat); // p의 값이 0이나 1일때 normalCat을 Instantiate(생성)출력 한다.
        }
        //lv 2 50% 확률로 고양이를 더 생성
        else if (level == 2)
        {
            int p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }
        //lv 3 뚱뚱한 고양이를 생성해준다
        else if(level == 3)
        {
            Instantiate(fatCat);
        }
        else if(level == 4)
        {
            Instantiate(pirateCat);
        }
    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore()
    {
        score++;
        Debug.Log("현재 Score: " + score); // 
        level = score / 5;
        Debug.Log("현재 Level: " + level); // 

        score++; //= (score += 1)
        level = score / 5;
        levelTxt.text = level.ToString();
        levelFront.localScale = new Vector3((score - level * 5) / 5.0f, 1f, 1f);
    }
}
