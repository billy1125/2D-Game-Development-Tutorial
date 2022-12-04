using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D; // �إߤ@��2D�����ܼ�
    public float moveSpeed = 1.0f;     // �إߤ@�Ӥ��}(public)�B�I��moveSpeed
    private Animator m_animator;       // �إߤ@�Ӱʵe����ܼ�

    public GameManager m_gameManager; // �إߤ@�Ӥ��}���ܼơA�Ψө�GameManger���C������
    public int lifeAmount = 100;      // �إߤ@�Ӿ���ܼơA�N��~�P�H�򥻥ͩR���ܼ�
    public int score = 0;             // �إߤ@�Ӿ���ܼơA�ΨӦs����

    AudioSource audioSource;          // �إߤ@��AudioSource���������ܼ�
    public AudioClip damage;          // �إߤ@�Ӥ��}���n�����ܼơA�����ˮ`���n��
    public AudioClip get;             // �إߤ@�Ӥ��}���n�����ܼơA��Y��������n��

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>(); // �C���@����A���o�~�P�H������
        m_animator = GetComponent<Animator>();       // �C���@����A���o�~�P�H���ʵe���
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �p�G���U��L�k��V��A���~�P�H��X�b����1
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_rigidbody2D.velocity = new Vector3(moveSpeed, 0, 0);
        }
        // �p�G���U��L����V��A���~�P�H��X�b����-1�A�]�N�O��������1
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_rigidbody2D.velocity = new Vector3(-moveSpeed, 0, 0);
        }
        // �p�G�k��V��u�Ρv����V��A�Q�u��}�v���ɭԡA�N���Ҧ��t�׳��k0
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_rigidbody2D.velocity = new Vector3(0, 0, 0);
        }
        // �p�G���U��L�ť���A���~�P�H��Y�b����1�A�]�N�O���W����1
        if (Input.GetKey(KeyCode.Space))
        {
            m_rigidbody2D.velocity = new Vector3(0, moveSpeed, 0);
        }

        // �C������t��
        float speedx = Mathf.Abs(m_rigidbody2D.velocity.x);
        // �̹C�����⪺�t�ק��ܰʵe���t��
        m_animator.speed = speedx / 2.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
	    // �p�G�I�쪺�O�a��Monster���Ҫ�����
        if (collision.gameObject.tag == "Monster")
        {
            lifeAmount -= 10; // ���ͩR��10�I
            m_gameManager.m_HPBar.fillAmount -= 0.1f; // ��u���0.1����
            audioSource.PlayOneShot(damage); // �������ˮ`������

            if (lifeAmount == 0) // �p�G�ͩR���k�s�A�R���ۤv�A�C������
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Intro");
            }
        }
        else if (collision.gameObject.tag == "Gold")
        {
            score += 10; // �[�Q��
            m_gameManager.m_ScoreText.text = score.ToString(); // ��sUI���Ƥ�r
            audioSource.PlayOneShot(get); // ����Y�����������
        }
    }
}