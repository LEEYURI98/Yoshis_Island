using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario_Move : MonoBehaviour
{
    public PlayerController player;
    Rigidbody2D enemyR;
    public int nextMove = -1;//행동지표를 결정할 변수
    public bool isMario = false;
    [SerializeField] private GameObject babyMario;
    private AudioSource audio;
    // Start is called before the first frame update
    private void Awake()
    {
        enemyR = GetComponent<Rigidbody2D>();
        ChangeMove();
        Invoke("ChangeMove", 5f);//Invoke();주어진 시간이 지난 후 지정된 함수를 실행 
        
    }

    private void Start()
    {

        audio = transform.GetComponent<AudioSource>();
        player = GameObject.Find("Yoshis").GetComponent<PlayerController>();
        //플레이어 위치에서 시작     
        audio.Play();
    }

    void FixedUpdate()
    {
        
        enemyR.velocity = new Vector2(nextMove * 0.3f, 1 * 0.3f); //단순 왼쪽방향 이동 
    }

    //행동지표를 바꿔줄 로직
    void ChangeMove()
    {
        nextMove = Random.Range(-1, 1);
        
        if (nextMove == -1)
        {
            
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (nextMove == 0)
        {
            nextMove = 1;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        Invoke("ChangeMove", 5f);//재귀함수 : 스스로 호출 딜레이 없이 재귀함수 사용은 좀 위험
    }

}
