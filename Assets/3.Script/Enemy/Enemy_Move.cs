using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    Rigidbody2D enemyR;

    public float speed = 0.3f; //몬스터 이동 속도
    public float dir = 5f;//방향 바꾸는 시간 간격

    private float moverDir = 1f;//몬스터 이동 방향
    private float time;

    void Start()
    {
        enemyR = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= dir)
        {
            time = 0f;
            moverDir *= -1f;
        }
        if (moverDir >0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (moverDir <= -1)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        enemyR.velocity = new Vector2(moverDir*speed, enemyR.velocity.y);

    } 
}
