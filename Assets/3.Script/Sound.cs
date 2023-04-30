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
        if (collision.CompareTag("Enter") && Input.GetKey(KeyCode.S))//지하맵으로 들어감
        {
            audio.clip = enterclip;
            audio.Play();
        }

        if (collision.CompareTag("Out"))//지하맵에서 나옴
        {
            audio.clip = enterclip;
            audio.Play();
        }
    }

}
