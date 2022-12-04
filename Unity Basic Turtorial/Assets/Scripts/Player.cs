using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D; // 建立一個2D剛體變數
    public float moveSpeed = 1.0f;     // 建立一個公開(public)浮點數moveSpeed
    private Animator m_animator;       // 建立一個動畫控制器變數

    public GameManager m_gameManager; // 建立一個公開的變數，用來放GameManger的遊戲物件
    public int lifeAmount = 100;      // 建立一個整數變數，代表外星人基本生命值變數
    public int score = 0;             // 建立一個整數變數，用來存分數

    AudioSource audioSource;          // 建立一個AudioSource音源元件變數
    public AudioClip damage;          // 建立一個公開的聲音檔變數，放受到傷害的聲音
    public AudioClip get;             // 建立一個公開的聲音檔變數，放吃到金幣的聲音

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>(); // 遊戲一執行，取得外星人的剛體
        m_animator = GetComponent<Animator>();       // 遊戲一執行，取得外星人的動畫控制器
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 如果按下鍵盤右方向鍵，讓外星人往X軸移動1
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_rigidbody2D.velocity = new Vector3(moveSpeed, 0, 0);
        }
        // 如果按下鍵盤左方向鍵，讓外星人往X軸移動-1，也就是往左移動1
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_rigidbody2D.velocity = new Vector3(-moveSpeed, 0, 0);
        }
        // 如果右方向鍵「或」左方向鍵，被「放開」的時候，就讓所有速度都歸0
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_rigidbody2D.velocity = new Vector3(0, 0, 0);
        }
        // 如果按下鍵盤空白鍵，讓外星人往Y軸移動1，也就是往上移動1
        if (Input.GetKey(KeyCode.Space))
        {
            m_rigidbody2D.velocity = new Vector3(0, moveSpeed, 0);
        }

        // 遊戲角色速度
        float speedx = Mathf.Abs(m_rigidbody2D.velocity.x);
        // 依遊戲角色的速度改變動畫的速度
        m_animator.speed = speedx / 2.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
	    // 如果碰到的是帶有Monster標籤的物件
        if (collision.gameObject.tag == "Monster")
        {
            lifeAmount -= 10; // 扣生命值10點
            m_gameManager.m_HPBar.fillAmount -= 0.1f; // 減短血條0.1長度
            audioSource.PlayOneShot(damage); // 播放受到傷害的音效

            if (lifeAmount == 0) // 如果生命值歸零，刪除自己，遊戲結束
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Intro");
            }
        }
        else if (collision.gameObject.tag == "Gold")
        {
            score += 10; // 加十分
            m_gameManager.m_ScoreText.text = score.ToString(); // 更新UI分數文字
            audioSource.PlayOneShot(get); // 播放吃到金幣的音效
        }
    }
}