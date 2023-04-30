using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinScore : MonoBehaviour
{
    [SerializeField] Text coin_text;
    public static int score;//코인 점수 저장

    private void Start()
    {
        coin_text = GetComponent<Text>();//이 스크립트가 붙은 오브젝트의 텍스트UI 컴포넌트 찾아서 저장
    }

    private void Update()
    {
        coin_text.text = "X " + score;//현재 스코어
    }
}
