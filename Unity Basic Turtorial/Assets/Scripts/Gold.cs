using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10); // 設定金幣預設行為，十秒後自動消失
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 如果金幣碰到一個物件，它的物件帶有「Player」標籤，就讓自己消失
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}