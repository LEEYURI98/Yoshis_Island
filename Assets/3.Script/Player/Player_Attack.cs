using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject egg_atk;//��
    public GameObject dir_sign;//���� ǥ���̹���

    public Transform pos;//�ش� ������Ʈ ���� ����
    private float speed;

    public PlayerController player;//�÷��̾� �� �� ���� �� �� ������ �ϰ� ���� ������ �� �ϳ��� ���������
    private AudioSource audio;
    public AudioClip atkclip;
    void Start()
    {
        audio = transform.GetComponent<AudioSource>();
        speed = 50f;
        dir_sign.transform.Rotate(new Vector3(0, 0, 0));
    }

    void Update()
    {
        if (player.egg > 0)//���� ���� ���� ���� �� ����
        {
            if (Input.GetKey(KeyCode.W) && Input.GetMouseButton(1))
            {

                dir_sign.transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.S) && Input.GetMouseButton(1))
            {
                dir_sign.transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime * -1));
            }
            if (Input.GetMouseButtonUp(1))
            {
                audio.clip = atkclip;
                audio.Play();
                Instantiate(egg_atk, pos.position, dir_sign.transform.rotation);
                player.egg--;
            }
        }
        
    }
}
