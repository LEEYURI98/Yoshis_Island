using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    Rigidbody2D enemyR;

    public float speed = 0.3f; //���� �̵� �ӵ�
    public float dir = 5f;//���� �ٲٴ� �ð� ����

    private float moverDir = 1f;//���� �̵� ����
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
