using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb = default;
    [SerializeField] float jumpPower=1f;
    [SerializeField] float dashPower = 5f;
    int jcount = 0;
    [SerializeField]string GroundTag = "Ground";
    [SerializeField] int jlimit = 2;
    [SerializeField] string EnemyTag = "Enemy";
    [SerializeField] MapGenerator generator;
    [SerializeField] string GeneratorTag = "Finish";
    [SerializeField] int dashPowerController;
    [SerializeField] UIManager uIManager;
    [SerializeField] int SpeedupTime = 10;
    float timer = 0f;
    //bool cJump;
    //Animator an = default;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //an=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(dashPower, rb.velocity.y, 0);
        if(uIManager.Timer>SpeedupTime)
        {
            dashPower += dashPowerController;
            SpeedupTime += SpeedupTime;
        }    
        if (jcount <jlimit)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity=new Vector3(0,jumpPower,0);
                jcount += 1;
            }
            if (Input.GetButton("Jump"))
            {
                timer += Time.deltaTime;

            }
        }
        //}
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.tag== GroundTag)
        {
            cJump = true;
            jcount=0;
        }*/
        if(collision.gameObject.tag== EnemyTag)
        {
            GameManager.GameOver();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag==GroundTag)
        {
            jcount = 0;
        }
        if(collision.gameObject.tag==GeneratorTag)
        {
            generator.GenerateStage();
        }
    }

}





