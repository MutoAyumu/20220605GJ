using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class odds : MonoBehaviour
{
    [SerializeField] float m_jumpPower = 15000f;
    [SerializeField] float speed; //速度
    [SerializeField] float gravity; //重力　
    [SerializeField] float timelimit = 0;

    public bool GroundCheck ; //接地判定
    int r;
    int jumpcount = 0;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;
    float time;
   


    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        r = Random.Range(1, 100);

        if (r >= 81 && jumpcount <= 2)
        {
            this.m_rb.AddForce(transform.up * m_jumpPower * 5);
            jumpcount++;
        }


        
        
    }
}
