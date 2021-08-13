using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeJugador : MonoBehaviour {

    public float MaxSpeed = 10f;
    public float speed = 2f;
    public bool EnElSuelo;
    public float poderDeSalto = 6.5f;


    private Rigidbody2D rgbd2d;
    private Animator anim;
    private bool salto;
    
    // Use this for initialization
	void Start () {
        rgbd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed",Mathf.Abs( rgbd2d.velocity.x));
        anim.SetBool("EnElSuelo",EnElSuelo);
        if (Input.GetKeyDown(KeyCode.UpArrow)&&EnElSuelo)
        {
            salto = true;

        }

    }
    //soluciona problemas...
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rgbd2d.AddForce(Vector2.right * speed * h);
        float VelocidadLimitada = Mathf.Clamp(rgbd2d.velocity.x,-MaxSpeed, MaxSpeed);
        rgbd2d.velocity = new Vector2(VelocidadLimitada, rgbd2d.velocity.y);
        if (h>0.1f) {
            transform.localScale = new Vector3(1f,1f,1f);
        }
        if (h <-0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (salto)
        {
            rgbd2d.AddForce(Vector2.up*poderDeSalto,ForceMode2D.Impulse);
            salto = false;
        }


        Debug.Log(rgbd2d.velocity.x);


    }
}
