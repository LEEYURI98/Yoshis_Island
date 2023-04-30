using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_Controller : MonoBehaviour
{
    public PlayerController player;

    private void OnCollisionEnter2D(Collision2D collision)
    {     
        if (collision.gameObject.CompareTag("Player"))
        {
            player.egg++;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
           Destroy(gameObject, 5);
        }
    }

}
