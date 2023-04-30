using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_move : MonoBehaviour
{
    public Rigidbody2D eggR;
    public int nextMove = -1;//행동지표를 결정할 변수
    public float moveSpeed = 5f;

    private void Awake()
    {
        eggR = GetComponent<Rigidbody2D>();
        ChangeMove();

        Invoke("ChangeMove", 5f);//Invoke();주어진 시간이 지난 후 지정된 함수를 실행
    }

    void FixedUpdate()
    {
        eggR.velocity = new Vector2(nextMove * 0.3f, eggR.velocity.y); //방향 이동
                                                                     
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
        Invoke("ChangeMove", 7f);//재귀함수 : 스스로 호출 딜레이 없이 재귀함수 사용은 좀 위험


    }
    
}
