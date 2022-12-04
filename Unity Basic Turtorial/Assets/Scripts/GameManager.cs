using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI物件的函式庫

public class GameManager : MonoBehaviour
{
    public GameObject MonsterPrefab; // 置放Prefab的變數
    float MonsterSpawnSpan = 1.0f;   // 預設時間長度
    float MonsterDelta = 0;          // 現在已經累積的時間

    public GameObject GoldPrefab;   // 置放Prefab的變數
    float GoldSpawnSpan = 3.0f;     // 預設時間長度
    float GoldDelta = 0;            // 現在已經累積的時間

    public Image m_HPBar;           // 血條圖片
    public Text m_ScoreText;        // 分數文字

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MonsterDelta += Time.deltaTime; // 不斷累積時間
        // 如果累積的時間大於預設的時間長度，就依據Prefab產生遊戲物件
        if (MonsterDelta > MonsterSpawnSpan)
        {
            MonsterDelta = 0; // 將累積時間歸零
            Instantiate(MonsterPrefab, new Vector3(6, -2, 0), Quaternion.identity); // 產生遊戲物件
        }

        GoldDelta += Time.deltaTime; // 不斷累積時間
        // 如果累積的時間大於預設的時間長度，就依據Prefab產生遊戲物件
        if (GoldDelta > GoldSpawnSpan)
        {
            GoldDelta = 0; // 將累積時間歸零
            int px = Random.Range(-9, 9);
            Instantiate(GoldPrefab, new Vector3(px, 7, 0), Quaternion.identity); // 產生遊戲物件
        }
    }
}
