using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb = default;
    [SerializeField] float jumpPower = 1f;
    [SerializeField] float dashPower = 5f;
    int jcount = 0;
    [SerializeField] string GroundTag = "Ground";
    [SerializeField] int jlimit = 2;
    [SerializeField] string EnemyTag = "Enemy";
    [SerializeField] MapGenerator generator;
    [SerializeField] string GeneratorTag = "Finish";
    [SerializeField] int dashPowerController;
    [SerializeField] UIManager uIManager;
    [SerializeField] int SpeedupTime = 10;
    [SerializeField] float jumpTimelimit = 3f;
    [SerializeField] string StarTag = "Star";
    [SerializeField] float StarTime = 1f;
    [SerializeField] string CoinTag = "Coin";
    [SerializeField] ParticleSystem _system;
    [SerializeField] AudioSource c_audio;
    [SerializeField] AudioSource s_audio;
    [SerializeField] CinemachineImpulseSource source;
    [SerializeField] GameObject StarEffect;
    float StartStarTime;
    float timer = 0f;
    bool isfirstjump = false;
    float subjump = 0f;
    bool isStar = false;
    bool isStart;
    [SerializeField]AudioSource j_audio = default;
    //bool cJump;
    //Animator an = default;


    // Start is called before the first frame update
    private void Awake()
    {
        GameManager.OnStart.AddListener(OnStart);
    }

    void OnStart()
    {
        rb = GetComponent<Rigidbody2D>();
        //an=GetComponent<Animator>();
        subjump = jumpPower;
        isStart = true;
        j_audio = GetComponent<AudioSource>();
        c_audio = GetComponent<AudioSource>();
        s_audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!isStart)
            return;

        rb.velocity = new Vector3(dashPower, rb.velocity.y, 0);
        if (uIManager.Timer > SpeedupTime)
        {
            dashPower += dashPowerController;
            SpeedupTime += SpeedupTime;
        }
        if (jcount < jlimit)
        {
            if (Input.GetButtonDown("Fire1") /*&& !isfirstjump*/)
            {
                j_audio.Play();
                rb.velocity = new Vector3(0, jumpPower, 0);
                jcount += 1;
                isfirstjump = true;
            }
            if (Input.GetButton("Fire1") && timer < jumpTimelimit && jcount!=0)
            {
                timer += Time.deltaTime;
                rb.velocity = new Vector3(dashPower, jumpPower - timer, 0);
            }
            if (Input.GetButtonUp("Fire1"))
            {
                timer = 0f;
                //sfirstjump = false;
                jumpPower = subjump;
            }
        }
        if (isStar)
        {
            if (StartStarTime + StarTime < uIManager.Timer)
            {
                isStar = false;
                StarEffect.SetActive(false);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.tag== GroundTag)
        {
            cJump = true;
            jcount=0;
        }*/
        if (collision.gameObject.tag == EnemyTag )
        {
            if (isStar)
            {
                var e = collision.gameObject.GetComponent<EnemyDestroy>();  
                
                if(e)
                {
                    e.Destroy();
                }
            }
            else
            {
                GameManager.GameOver();
                Destroy(this.gameObject);
                var p = Instantiate(_system, this.transform.position, Quaternion.identity);
                p.transform.Rotate(new Vector3(90, 0,0));
                source.GenerateImpulse();
            }
        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GroundTag)
        {
            jcount = 0;
        }
        if (collision.gameObject.tag == GeneratorTag)
        {
            generator.GenerateStage();
        }
        if(collision.gameObject.tag == StarTag)
        {
            s_audio.Play();
            OnStar();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag== CoinTag)
        {
            GameManager.AddScore(20);
            c_audio.Play();
            Destroy(collision.gameObject);
        }

    }

    private void OnStar()
    {
        isStar = true;
        StartStarTime = uIManager.Timer;
        StarEffect.SetActive(true);
    }

}





