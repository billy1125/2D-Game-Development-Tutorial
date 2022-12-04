using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 場景管理的函式庫

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 如果滑鼠左鍵被按下去
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("SampleScene"); // 讀取SampleScene場景
        }
    }
}
