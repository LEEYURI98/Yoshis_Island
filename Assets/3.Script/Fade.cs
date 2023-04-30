using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image Panel;
    float time = 0;
    float F_time = 1;

    private void Update()
    {
        StartCoroutine(_Fade());
    }


    IEnumerator _Fade()
    {
        yield return new WaitForSeconds(2f);
        Panel.gameObject.SetActive(true);//루틴이 시작 될 때 이미지를 활성화

        Color alpha = Panel.color;

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }

    }

}
