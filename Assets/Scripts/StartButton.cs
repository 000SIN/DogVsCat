using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        //버튼을 누르면 메인씬을 로드할 것이다.
    }
}
