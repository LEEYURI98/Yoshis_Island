using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enter : MonoBehaviour
{
    public Image Panel;// 이미지 변수 선언
    float time = 0;// 0~1까지 deltatime을 계속 더하여 지속시간으로 씀
    float F_time = 1;//페이트가 몇 초간 지속될지 정하는 값

    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.CompareTag("Enter") && Input.GetKey(KeyCode.S))//지하맵으로 들어감
        {            
            StartCoroutine(Fade());//화면 가리기 //코루틴을 이용 
            transform.position = new Vector3(23.8f, -4.65f, 0);
        }
 
        if (collision.CompareTag("Out"))//지하맵에서 나옴
        {
            StartCoroutine(Fade());
            transform.position = new Vector3(23.586f, 1.4f, 0);          
        } 
    }

    IEnumerator Fade()
    {
        Panel.gameObject.SetActive(true);//루틴이 시작 될 때 이미지를 활성화
        time = 0f;//코루틴 시작할 쯤에 time을 0으로 초기화
        Color alpha = Panel.color;
        //페이드 아웃
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;// 매 프레임 deltatime을 F_time으로 나눈 값을 time에 더해준다.
            alpha.a = Mathf.Lerp(1, 1, time);//Mathf.Lerp()을 이용해 부드럽게 바뀌게 해줌
            Panel.color = alpha; //alpha의 값을 매 프레임 이미지의 컬러 값에 대입
            yield return null;
        }

        time = 0f;//반복문 사이에 time초기화

        yield return new WaitForSeconds(1.5f);//대기 시간

        //페이드 인
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
    }
}
