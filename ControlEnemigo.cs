using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour {

    public float Speed = 2f;
    public float MaxSpeed = 5f;
    public int ptsporEnmgigo;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb2d.AddForce(Vector2.right*Speed);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -MaxSpeed, MaxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        //if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        //{
        //    Speed = -Speed;
        //    rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
        //}
        ////cabiar lado
        //if (Speed < 0f)
        //{
        //    transform.eulerAngles = new Vector3(1f, 1f, 1f);
        //}
        //if (Speed > -0f)
        //{
        //    transform.eulerAngles = new Vector3(-1f, 1f, 1f);
        //}
       

    }
    //otra cosa
 void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float yoffset = 1.035f;
            if (transform.position.y + yoffset < col.transform.position.y)
            {
                col.SendMessage("EnemyJump");
                Destroy(gameObject);
                GameMaster gm2 = new GameMaster();
                gm2 = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
                gm2.points += ptsporEnmgigo;


            }
            else
            {
                col.SendMessage("ChoqueEnemigo",transform.position.x);
            }
        } 
    }
}
