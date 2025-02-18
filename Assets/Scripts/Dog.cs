using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject food; //prefab
    
    void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.5f); // 0f부터 시작해서 0.5f마다 재생성
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x;

        if(x > 8.5f)
        {
            x = 8.5f;
        }
        if(x <-8.5f)
        {
            x = -8.5f;
        }
        transform.position = new Vector2(x, transform.position.y);   
    }

    // Update is called once per frame
    void MakeFood()
    {
        float x = transform.position.x;
        float y = transform.position.y + 2.0f;
        Instantiate(food, new Vector2(x,y), Quaternion.identity); //Quaternion = 회전값 없이
    }
}
