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
    [SerializeField] float jumpTimelimit = 3f;
    float timer = 0f;
    bool isfirstjump=false;
    float subjump = 0f;
    //bool cJump;
    //Animator an = default;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //an=GetComponent<Animator>();
        subjump = jumpPower;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(dashPower, rb.velocity.y, 0);
        if(uIManager.Timer>SpeedupTime)
        {
            dashPower += dashPowerController;
            SpeedupTime+=SpeedupTime;
        }    
        if (jcount <jlimit)
        {
            if (Input.GetButtonDown("Jump")&&!isfirstjump)
            {
                rb.velocity=new Vector3(0,jumpPower,0);
                jcount += 1;
                isfirstjump = true;
            }
            if (Input.GetButton("Jump")&&timer<jumpTimelimit)
            {
                timer += Time.deltaTime;
                rb.velocity = new Vector3(dashPower, jumpPower - timer, 0); 
            }
            if(Input.GetButtonUp("Jump"))
            {
                timer = 0f;
                isfirstjump = false;
                jumpPower = subjump;
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





