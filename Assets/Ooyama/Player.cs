using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb = default;
    [SerializeField] float jumpPower=1f;
    int jcount = 0;
    [SerializeField]string GroundTag = "Ground";
    [SerializeField] int jlimit = 2;
    //bool cJump;
    //Animator an = default;
    //bool GO;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //an=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector3(10.0f,rb.velocity.y, 0);
        //if(cjump==true)
        //{ 
        if (jcount <jlimit)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jcount += 1;
            }
        }
        //}
     
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag== GroundTag)
        {
            //cJump = true;
            jcount=0;
        }
        /*if(collision.gameObject.tag=="Enemy")
        {
            GO=true;
        }*/
    }

}





