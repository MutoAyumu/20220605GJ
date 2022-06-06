using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class odds : MonoBehaviour
{
    [SerializeField] float e_jumpPower = 100f;
    /*[SerializeField] float speed; 
    [SerializeField] float gravity; */
    //[SerializeField] GameObject e_prefab = default;
    [SerializeField] float e_interval = 1f;
    [SerializeField] bool e_jumpStart = true;
    float e_timer;

    //public bool GroundCheck ; 
    int r;
    int jumpcount = 0;
    
    Rigidbody2D e_rb = default;
    SpriteRenderer e_sprite = default;


    private void Awake()
    {
        GameManager.OnStart.AddListener(OnStart);
    }

    private void OnStart()
    {
        e_rb = GetComponent<Rigidbody2D>();
        e_sprite = GetComponent<SpriteRenderer>();

        if (e_jumpStart)
        {
            e_timer = e_interval;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        e_timer += Time.deltaTime;

        
        if (e_timer > e_interval)
        {
            e_timer = 0;
            r = Random.Range(1, 100);

            if (r >= 81 && jumpcount <= 2)
            {
                this.e_rb.AddForce(transform.up * e_jumpPower * 5);
                jumpcount++;
            }
            //Instantiate(e_prefab, this.transform.position, Quaternion.identity);
        }


    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpcount = 0;
        }
    }
}
