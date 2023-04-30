using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_Atk : MonoBehaviour
{
    public float speed;
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 5);
    }

}
