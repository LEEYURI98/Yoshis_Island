using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip enterclip;
    void Start()
    {
        audio = transform.GetComponent<AudioSource>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enter") && Input.GetKey(KeyCode.S))//���ϸ����� ��
        {
            audio.clip = enterclip;
            audio.Play();
        }

        if (collision.CompareTag("Out"))//���ϸʿ��� ����
        {
            audio.clip = enterclip;
            audio.Play();
        }
    }

}
