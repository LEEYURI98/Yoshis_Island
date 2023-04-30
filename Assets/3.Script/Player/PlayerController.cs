using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float jumpPower = 100f;
    private Rigidbody2D playerR;
    
    private Animator ani;//Animator�� Animation �� �����ؼ� ����
    private Movement movement;// Movement ����

    public GameObject MainPlay;
    [SerializeField] private GameObject babyMario;//������ ������Ʈ ��/Ȱ��ȭ �ϱ� ����
    [SerializeField] private GameObject player_tongue;//���� ���� ���
    [SerializeField] private GameObject countDown;//�������� ���� ������Ʈ ��/Ȱ��ȭ
    [SerializeField] private GameObject Dir_sign;//���� ���� ������Ʈ ��/Ȱ��ȭ �ϱ� ����
    public GameObject[] Egg_follow;//�� ������� �ϱ�

    //���� ����
    [SerializeField] public bool isRun = false;//�޸���
    public bool isJump = false;//����
    public bool isFall = false;//������
    public bool isEat = false;//���� ���� ���
    public bool isEating = false;//���� �� �ȿ� ����
    public bool isDown = false;//
    public bool isMakeEgg = false;//���� �˷� ����
    public bool isCatch = false;//���͸� ����
    public bool isYoshi = false;//�������� ������ �޾Ƽ� �������� �и�
    public bool isMario = false;//�������� �и�����
    public bool isRun_C = false;//�������� �и� �� �޸���
    public bool isAttack = false;//�� ������
    public bool isReady = false;//�� ������ �غ��ڼ�
    private int count = 1; //���Ϳ� �浹�� ������ �������� ��⵵ ���� ��ġ �ٲ�� �� �����ϱ� ����
    public int egg = 0; //�� ����
    public bool isgoal = false;//�����ϸ�


    //---------------------------------
    // �����
    
    private AudioSource audio;

    public AudioClip eatclip;//������
    public AudioClip jumpclip;
    public AudioClip eggGetclip;//�� ���� ��
    public AudioClip coinclip;//���� ���� ��


    

    private void Awake()
    {
        //�ʱ�ȭ
        playerR = transform.GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        movement = transform.GetComponent<Movement>();
        audio = transform.GetComponent<AudioSource>();
    }

    void Start()//����Ƽ���� ���ڰ� �����Ǵ� ��찡 �ֱ� ������ ���⼭ �ϸ� ���߿� �ӵ� �����ϱ� ����
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
        // A, D �Ǵ� ��, �����Ű�� �Է¹���
        // X�� �̵����� ����(��, ��)
        //
        float y = Input.GetAxisRaw("Vertical");
        // W, S �Ǵ� ��, �� ����Ű�� �Է¹���
        // Y�� �̵����� ����(��, ��)
        if (egg >= 7)
        {
            egg = 7;
        }
        isCatch = false;
        Run();//�¿�޸���       
        Jump();//���� 
        Eat();
        Down();
        Egg();  
        Attack();
        
        movement.MoveTo(new Vector3(x, 0, 0f));
        //Movement�� �Է°��� ������ �׸��� ���⺤�͸� ��Ÿ����.
        //2D�̱� ������ z��ǥ�� ����� ���� ���� ������ 0f
    }
  
    //- �ൿ ---------------------------------
    private void Run()
    {
        //�� ������ �ִ� falseó��
        //����
        bool condition =
        (isJump == false) &&
        (isFall == false) &&
        (isDown == false);



        if (Input.GetKey(KeyCode.A) && condition)
        {
            isRun = false;
            isRun = true;
            transform.localEulerAngles = new Vector3(0, 180, 0);//���� �����ʿ� ���� ĳ���� ���� ����
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
        if (Input.GetKey(KeyCode.W) && (isJump == false) && (isEat == false) && (!Input.GetMouseButton(1)))//�� ������ ����Ű�� �и��ϱ� ����(!Input.GetMouseButton(1)�߰�
        {
            audio.clip = jumpclip;
            audio.Play();//���� ���� ���
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
            playerR.velocity = Vector2.zero;//���� ������ �ӵ��� ���������� ���η� ����
            playerR.AddForce(new Vector2(0, jumpPower));//�÷��̾� ������ٵ� �������� ���ֱ�

        }
        if (playerR.velocity.y <= -0.5 && isJump == true)//�������� ���� Fall �ִ� ���
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

        if (Input.GetMouseButtonUp(0))//�ٽ� �� edge false ó��
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

    void Egg()//�ڿ� ������� ��
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

    void Attack()//�� ������ ����
    {
        if (egg > 0)//���� ���� ���� ���� �� ����
        {
            if (Input.GetMouseButton(1))
            {
                isReady = true;
                Dir_sign.SetActive(true);//�� ���� ����Ű�� �� ��� Ȱ��ȭ
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            isReady = false;

            Dir_sign.SetActive(false);
            
        }
        ani.SetBool("Ready", isReady);    
    }

    //�浹 ó��
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

        if (collision.gameObject.CompareTag("Enemy") && isCatch == false)//���Ϳ� �浹
        {
            isYoshi = true;
            
            babyMario.SetActive(true);
            countDown.SetActive(true);//������ Ȱ��ȭ �Ǹ鼭 ���� ī��Ʈ Ȱ��ȭ
            ani.SetBool("Yoshi", isYoshi);
            if (count == 1)
            {
                babyMario.transform.position = new Vector3(MainPlay.transform.position.x - 0.5f, MainPlay.transform.position.y + 0.5f, 0);
                count--;
            }

        }
        if (collision.gameObject.CompareTag("Mario"))//����������
        {
            babyMario.SetActive(false);
            countDown.SetActive(false);//������ Ȱ��ȭ �Ǹ鼭 ���� ī��Ʈ ��Ȱ��ȭ
            isYoshi = false;
            ani.SetBool("Yoshi", isYoshi);

            count = 1;
        }

        //������

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
        if (collision.gameObject.CompareTag("Coin"))//���� �Ҹ�
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
