using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinScore : MonoBehaviour
{
    [SerializeField] Text coin_text;
    public static int score;//���� ���� ����

    private void Start()
    {
        coin_text = GetComponent<Text>();//�� ��ũ��Ʈ�� ���� ������Ʈ�� �ؽ�ƮUI ������Ʈ ã�Ƽ� ����
    }

    private void Update()
    {
        coin_text.text = "X " + score;//���� ���ھ�
    }
}
