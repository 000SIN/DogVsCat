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
        Application.targetFrameRate = 60; //��� ��ǻ���� ������ ���� �Ȱ��� �����ֱ�
        Time.timeScale = 1.0f;

        level = 0; //level �ʱ�ȭ �߰�
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
        Debug.Log("���� Level: " + level);
        Instantiate(normalCat);//normalCat �������� **������(�ν��Ͻ�)�� ���� ����.
                               //���� ��� p�� 0, 1, 2�� ���� �ƹ��͵� �������� ����(30 % Ȯ���� ����� �� ����).
                               //��, ���� ���� ���� ����̰� �ƿ� �� ���� ���� �ִ� ��Ȳ�� ��.
                               //�̸� �����ϱ� ���� ������ �� ������ �����ǵ��� �ڵ尡 �߰��� ��. 
        //Iv.1 20% Ȯ���� ����̸� �� ����
        if (level == 1)
        {
            int p = Random.Range(0, 10); // p��� ���� 0~9 ������ ���� �߿��� �������� ����
            if (p < 2) Instantiate(normalCat); // p�� ���� 0�̳� 1�϶� normalCat�� Instantiate(����)��� �Ѵ�.
        }
        //lv 2 50% Ȯ���� ����̸� �� ����
        else if (level == 2)
        {
            int p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }
        //lv 3 �׶��� ����̸� �������ش�
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
        Debug.Log("���� Score: " + score); // 
        level = score / 5;
        Debug.Log("���� Level: " + level); // 

        score++; //= (score += 1)
        level = score / 5;
        levelTxt.text = level.ToString();
        levelFront.localScale = new Vector3((score - level * 5) / 5.0f, 1f, 1f);
    }
}
