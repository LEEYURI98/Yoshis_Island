using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour
{

    [SerializeField] private GameObject goal;
    private AudioSource audio;
    public Image Panel;
    float time = 0;
    float F_time = 1;


    void Start()
    {
        audio = transform.GetComponent<AudioSource>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audio.Play();
            goal.SetActive(true);
            Invoke("Ending", 2.5f);
        }
    }

    void Ending()
    {
        SceneManager.LoadScene("Ending");
    }
}
