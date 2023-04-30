using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enter : MonoBehaviour
{
    public Image Panel;// �̹��� ���� ����
    float time = 0;// 0~1���� deltatime�� ��� ���Ͽ� ���ӽð����� ��
    float F_time = 1;//����Ʈ�� �� �ʰ� ���ӵ��� ���ϴ� ��

    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.CompareTag("Enter") && Input.GetKey(KeyCode.S))//���ϸ����� ��
        {            
            StartCoroutine(Fade());//ȭ�� ������ //�ڷ�ƾ�� �̿� 
            transform.position = new Vector3(23.8f, -4.65f, 0);
        }
 
        if (collision.CompareTag("Out"))//���ϸʿ��� ����
        {
            StartCoroutine(Fade());
            transform.position = new Vector3(23.586f, 1.4f, 0);          
        } 
    }

    IEnumerator Fade()
    {
        Panel.gameObject.SetActive(true);//��ƾ�� ���� �� �� �̹����� Ȱ��ȭ
        time = 0f;//�ڷ�ƾ ������ �뿡 time�� 0���� �ʱ�ȭ
        Color alpha = Panel.color;
        //���̵� �ƿ�
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;// �� ������ deltatime�� F_time���� ���� ���� time�� �����ش�.
            alpha.a = Mathf.Lerp(1, 1, time);//Mathf.Lerp()�� �̿��� �ε巴�� �ٲ�� ����
            Panel.color = alpha; //alpha�� ���� �� ������ �̹����� �÷� ���� ����
            yield return null;
        }

        time = 0f;//�ݺ��� ���̿� time�ʱ�ȭ

        yield return new WaitForSeconds(1.5f);//��� �ð�

        //���̵� ��
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
    }
}
