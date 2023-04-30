using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float jumpPower = 100f;
    private Rigidbody2D playerR;
    
    private Animator ani;//Animator와 Animation 잘 구분해서 쓰기
    private Movement movement;// Movement 블러옴

    public GameObject MainPlay;
    [SerializeField] private GameObject babyMario;//마리오 오브젝트 비/활성화 하기 위해
    [SerializeField] private GameObject player_tongue;//혀로 몬스터 잡기
    [SerializeField] private GameObject countDown;//마리오랑 같이 오브젝트 비/활성화
    [SerializeField] private GameObject Dir_sign;//공격 방향 오브젝트 비/활성화 하기 위해
    public GameObject[] Egg_follow;//알 따라오게 하기

    //동작 조건
    [SerializeField] public bool isRun = false;//달리기
    public bool isJump = false;//점프
    public bool isFall = false;//떨어짐
    public bool isEat = false;//혀로 몬스터 잡기
    public bool isEating = false;//몬스터 입 안에 있음
    public bool isDown = false;//
    public bool isMakeEgg = false;//몬스터 알로 만듦
    public bool isCatch = false;//몬스터를 잡음
    public bool isYoshi = false;//몬스터한테 데미지 받아서 마리오와 분리
    public bool isMario = false;//마리오와 분리여부
    public bool isRun_C = false;//마리오와 분리 후 달리기
    public bool isAttack = false;//알 던지기
    public bool isReady = false;//알 던지기 준비자세
    private int count = 1; //몬스터와 충돌할 때마다 마리오를 잡기도 전에 위치 바뀌는 거 고정하기 위해
    public int egg = 0; //알 개수
    public bool isgoal = false;//골인하면


    //---------------------------------
    // 오디오
    
    private AudioSource audio;

    public AudioClip eatclip;//먹을때
    public AudioClip jumpclip;
    public AudioClip eggGetclip;//알 먹을 때
    public AudioClip coinclip;//코인 얻을 때


    

    private void Awake()
    {
        //초기화
        playerR = transform.GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        movement = transform.GetComponent<Movement>();
        audio = transform.GetComponent<AudioSource>();
    }

    void Start()//유니티에서 숫자가 고정되는 경우가 있기 때문에 여기서 하면 나중에 속도 변경하기 좋음
    {
        //movement.moveSpeed = 2f;
        if (movement.moveSpeed <= 10f)
        {
            movement.moveSpeed = 2f;
        }

    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        // A, D 또는 ←, →방향키를 입력받음
        // X축 이동값을 저장(좌, 우)
        //
        float y = Input.GetAxisRaw("Vertical");
        // W, S 또는 ↑, ↓ 방향키를 입력받음
        // Y축 이동값을 저장(상, 하)
        if (egg >= 7)
        {
            egg = 7;
        }
        isCatch = false;
        Run();//좌우달리기       
        Jump();//점프 
        Eat();
        Down();
        Egg();  
        Attack();
        
        movement.MoveTo(new Vector3(x, 0, 0f));
        //Movement에 입력값을 보내줌 그리고 방향벡터를 나타낸다.
        //2D이기 때문에 z좌표는 사용할 일이 없기 때문에 0f
    }
  
    //- 행동 ---------------------------------
    private void Run()
    {
        //알 던지는 애니 false처리
        //조건
        bool condition =
        (isJump == false) &&
        (isFall == false) &&
        (isDown == false);



        if (Input.GetKey(KeyCode.A) && condition)
        {
            isRun = false;
            isRun = true;
            transform.localEulerAngles = new Vector3(0, 180, 0);//왼쪽 오른쪽에 따라 캐릭터 방향 변경
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isRun = false;
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D) && condition)
        {
            isRun = false;
            isRun = true;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isRun = false;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        ani.SetBool("Run", isRun);    
    }    

    private void Jump()
    {
        if (Input.GetKey(KeyCode.W) && (isJump == false) && (isEat == false) && (!Input.GetMouseButton(1)))//알 던지는 방향키랑 분리하기 위해(!Input.GetMouseButton(1)추가
        {
            audio.clip = jumpclip;
            audio.Play();//점프 사운드 재생
            isJump = true;
            isRun = false;
            if (Input.GetKey(KeyCode.A))
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }          
            playerR.velocity = Vector2.zero;//점프 직전의 속도를 순간적으로 제로로 변경
            playerR.AddForce(new Vector2(0, jumpPower));//플레이어 리지드바디에 위쪽으로 힘주기

        }
        if (playerR.velocity.y <= -0.5 && isJump == true)//떨어지는 동안 Fall 애니 재생
        {           
            isFall = true;            
        }

        ani.SetBool("Jump", isJump);
        ani.SetBool("Fall", isFall);

    }

    private void Eat()
    {
        if (Input.GetMouseButton(0))
        {
            audio.clip = eatclip;
            audio.Play();
            isJump = false;
            isFall = false;
            isEat = true;
            player_tongue.SetActive(true);

        }

        ani.SetBool("Eat", isEat);
        
        if (Input.GetMouseButtonDown(0))
        {
            isEating = true;
            ani.SetBool("Eating", isEating);
        }

        if (Input.GetMouseButtonUp(0))//다시 그 edge false 처리
        {
            player_tongue.SetActive(false);
        }

        isEating = false;
        isEat = false;


    }
    private void Down()
    {
        if (Input.GetKey(KeyCode.S))
        {
            isDown = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            isDown = false;
            isMakeEgg = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isDown = false;
            isMakeEgg = false;
        }
        ani.SetBool("Down", isDown);
        ani.SetBool("MakeEgg", isMakeEgg);
    }

    void Egg()//뒤에 따라오는 알
    {
        for (int i = 0; i < Egg_follow.Length; i++)
        {
            if (egg == i + 1)
            {
                Egg_follow[i].SetActive(true);
                break;
            }
        }

        for (int i = egg; i < Egg_follow.Length; i++)
        {
            Egg_follow[i].SetActive(false);
        }
    }

    void Attack()//알 던져서 공격
    {
        if (egg > 0)//알이 있을 때만 던질 수 있음
        {
            if (Input.GetMouseButton(1))
            {
                isReady = true;
                Dir_sign.SetActive(true);//그 방향 가르키는 그 모양 활성화
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            isReady = false;

            Dir_sign.SetActive(false);
            
        }
        ani.SetBool("Ready", isReady);    
    }

    //충돌 처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Map" ||
            collision.gameObject.tag == "Enemy" ||
            collision.gameObject.tag == "Step" ||
            collision.gameObject.tag == "Jumping"
            )
        {
            playerR.velocity = Vector2.zero;
            isJump = false;
            isFall = false;
            
        }      

        if (collision.gameObject.CompareTag("Enemy") && isCatch == false)//몬스터와 충돌
        {
            isYoshi = true;
            
            babyMario.SetActive(true);
            countDown.SetActive(true);//마리오 활성화 되면서 같이 카운트 활성화
            ani.SetBool("Yoshi", isYoshi);
            if (count == 1)
            {
                babyMario.transform.position = new Vector3(MainPlay.transform.position.x - 0.5f, MainPlay.transform.position.y + 0.5f, 0);
                count--;
            }

        }
        if (collision.gameObject.CompareTag("Mario"))//마리오구함
        {
            babyMario.SetActive(false);
            countDown.SetActive(false);//마리오 활성화 되면서 같이 카운트 비활성화
            isYoshi = false;
            ani.SetBool("Yoshi", isYoshi);

            count = 1;
        }

        //점프대

        if (collision.gameObject.CompareTag("Jumping"))
        {
            jumpPower = 200f;
            playerR.AddForce(new Vector2(0, jumpPower));

            //if (collision.gameObject.CompareTag("Jumping") && Input.GetKey(KeyCode.W) && isJump == false)
            //{
            //    jumpPower = 300f;
            //    playerR.AddForce(new Vector2(0, jumpPower));
            //    jumpPower = 200f;
            //}
        }   
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))//코인 소리
        {
            audio.PlayOneShot(coinclip);
        }
        if (collision.gameObject.CompareTag("BonusEgg"))
        {
            audio.PlayOneShot(eggGetclip);
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            isgoal = true;
            ani.SetBool("Goal", isgoal);
        }
    }


}
