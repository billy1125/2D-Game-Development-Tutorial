using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
        m_rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidbody2D.velocity = new Vector3(-3, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
