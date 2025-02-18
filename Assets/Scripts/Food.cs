using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * 0.5f; //up = (0,1,0) * 0.5 = (0,0.5,0)
        if(transform.position.y > 27.0f)
        {
            Destroy(gameObject);
        }
    }


}
