using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarSuelo : MonoBehaviour {


    private PlayerController player;
    private Rigidbody2D rb2d;
    
    // Use this for initialization
	void Start () {
        player = GetComponentInParent<PlayerController>();
        rb2d = GetComponentInParent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Plataforma")
        {
            rb2d.velocity = new Vector3(0f,0f,0f);
            player.transform.parent = col.transform;
            player.grounded = true;
        }
    }


    private void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.tag == "ground")
        {
            player.grounded = true;
        }
        if (col.gameObject.tag == "Plataforma")
        {
            player.transform.parent = col.transform;
            player.grounded = true;
        }

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            player.grounded = false;
        }
        if (col.gameObject.tag == "Plataforma")
        {
            player.transform.parent = null;
            player.grounded = false;
        }
    }
}
