using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; //모든 컴퓨터의 프레임 수를 똑같이 맞춰주기
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * 0.05f;
    }
}
