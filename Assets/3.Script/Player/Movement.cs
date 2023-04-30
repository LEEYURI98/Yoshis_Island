using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;//다른 클래서에서 쓰기 위해 public 붙여줌
    [SerializeField] private Vector3 moveDirection = Vector3.zero;//방향
    private Rigidbody2D playerR;

    private void Awake()
    {
        //playerR = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        //playerR.MovePosition(transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime); //그 벽에 낄 때 버벅거림(?) 해결 코드 근데 중력(?)해결됨
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
