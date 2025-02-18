using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject hungryCat;
    public GameObject fullCat;

    public RectTransform front;

    float full = 5.0f;
    float energy = 0.0f;
    void Start()
    {
        Application.targetFrameRate = 60; //모든 컴퓨터의 프레임 수를 똑같이 맞춰주기
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full)
        {
            transform.position += Vector3.down * 0.05f;
        }
        else
        {
            if(transform.position.x > 0)
            {
                transform.position += Vector3.right * 0.05f;
            }
            else
            {
                transform.position += Vector3.left * 0.05f;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Food")) //Tag가 푸드인 오브젝트와 충돌시
        {
            if (energy < full)
            {
                energy += 1.0f;
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);
                Destroy(collision.gameObject);
            }
            else
            {
                hungryCat.SetActive(false);
                fullCat.SetActive(true);
            }
        }
        
    }
}

