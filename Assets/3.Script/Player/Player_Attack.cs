using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject egg_atk;//알
    public GameObject dir_sign;//방향 표시이미지

    public Transform pos;//해당 오브젝트 기준 방향
    private float speed;

    public PlayerController player;//플레이어 그 알 없을 때 못 던져야 하고 던질 때마다 알 하나씩 사라져야함
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
        if (player.egg > 0)//알이 있을 때만 던질 수 있음
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
