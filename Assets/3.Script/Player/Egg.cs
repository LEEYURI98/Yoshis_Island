using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public Vector3 followPos;
    public int followDelay;
    public Transform target;
    public Queue<Vector3> targetPos;

    private void Awake()
    {
        targetPos = new Queue<Vector3>();
    }

    private void Update()
    {
        Watch();//따라갈 위치를 계속 갱신해주는 함수 생성
        Follow();
    }

    void Watch()
    {
        //Input Pos

        targetPos.Enqueue(target.position); //Enqueue() : 큐에 데이터 저장하는 함수

        // Output Pos
        if (targetPos.Count > followDelay)
        {
            followPos = targetPos.Dequeue();
        }
    }

    void Follow()
    {
        transform.position = followPos;
    }
}
