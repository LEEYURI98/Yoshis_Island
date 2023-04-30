using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private GameObject step;
    [SerializeField] private GameObject flyEgg;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            flyEgg.SetActive(false);
            step.SetActive(true);
        }
    }
}
