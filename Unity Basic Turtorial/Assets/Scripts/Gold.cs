using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10); // �]�w�����w�]�欰�A�Q���۰ʮ���
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �p�G�����I��@�Ӫ���A��������a���uPlayer�v���ҡA�N���ۤv����
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}