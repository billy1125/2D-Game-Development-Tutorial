using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �����޲z���禡�w

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �p�G�ƹ�����Q���U�h
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("SampleScene"); // Ū��SampleScene����
        }
    }
}
