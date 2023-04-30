using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaffold : MonoBehaviour
{
    private Rigidbody2D playerR;
    int playerLayer, scaffoldLayer;

    void Start()
    {
        playerR = GetComponent<Rigidbody2D>();

        playerLayer   = LayerMask.NameToLayer("Player");
        scaffoldLayer = LayerMask.NameToLayer("Scaffold");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerR.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, scaffoldLayer, true);

        }
        else 
        {
            Physics2D.IgnoreLayerCollision(playerLayer, scaffoldLayer, false);

        }
    }
}
