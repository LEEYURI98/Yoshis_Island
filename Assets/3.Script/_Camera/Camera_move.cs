using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    //ī�޶� �÷��̾� ���󰡱�
    public GameObject target; //ī�޶� ���� ���
    public float moveSpeed;// ī�޶� ���� �ӵ�
    private Vector3 targetPos; //����� ���� ��ġ

    //------------------------
    

    private void Update()
    {
        if (target.gameObject != null)//����� �ִ��� Ȯ��
        {
            //LimitCameraArea();
            //this�� ī�޶� �ǹ�
            targetPos = new Vector3(target.transform.position.x+0.3f, target.transform.position.y + 0.3f, -10f);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
        //Lerp�� �ﰢ������ ī�޶� �÷��̾ ������ �ʰ� �ϱ� ���� ���
        //�� �� �ε巴�� ����
   
    }

    

    
}
