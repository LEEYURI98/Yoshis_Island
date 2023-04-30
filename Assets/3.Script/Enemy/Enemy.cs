using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyR;
    public PlayerController player;
    private Animator ani;
    public bool isDie= false;
    public bool isCatch= false;//�÷��̾�� ���� 
    public bool isCatching= false;//�÷��̾�� ����
    public int nextMove;
    public Vector3 pos;
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Die();
    }

    public void Die()
    {
        if (isCatch == true)
        {
            ani.SetBool("Catch", isCatch);

            if (Input.GetKey(KeyCode.S))
            {
                player.egg++;
                Destroy(gameObject);
            }
        }       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetMouseButton(0))//���� �Ա�
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
            isCatch = true;
        }
    }

}