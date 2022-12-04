using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI���󪺨禡�w

public class GameManager : MonoBehaviour
{
    public GameObject MonsterPrefab; // �m��Prefab���ܼ�
    float MonsterSpawnSpan = 1.0f;   // �w�]�ɶ�����
    float MonsterDelta = 0;          // �{�b�w�g�ֿn���ɶ�

    public GameObject GoldPrefab;   // �m��Prefab���ܼ�
    float GoldSpawnSpan = 3.0f;     // �w�]�ɶ�����
    float GoldDelta = 0;            // �{�b�w�g�ֿn���ɶ�

    public Image m_HPBar;           // ����Ϥ�
    public Text m_ScoreText;        // ���Ƥ�r

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MonsterDelta += Time.deltaTime; // ���_�ֿn�ɶ�
        // �p�G�ֿn���ɶ��j��w�]���ɶ����סA�N�̾�Prefab���͹C������
        if (MonsterDelta > MonsterSpawnSpan)
        {
            MonsterDelta = 0; // �N�ֿn�ɶ��k�s
            Instantiate(MonsterPrefab, new Vector3(6, -2, 0), Quaternion.identity); // ���͹C������
        }

        GoldDelta += Time.deltaTime; // ���_�ֿn�ɶ�
        // �p�G�ֿn���ɶ��j��w�]���ɶ����סA�N�̾�Prefab���͹C������
        if (GoldDelta > GoldSpawnSpan)
        {
            GoldDelta = 0; // �N�ֿn�ɶ��k�s
            int px = Random.Range(-9, 9);
            Instantiate(GoldPrefab, new Vector3(px, 7, 0), Quaternion.identity); // ���͹C������
        }
    }
}
