using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimiteDeVel : MonoBehaviour {

    public float Speed = 2f;
    public float MaxSpeed = 5f;
    public bool grounded;


    private Rigidbody2D rgb2d;
	// Use this for initialization
	void Start () {
        rgb2d = GetComponent<Rigidbody2D>();
	}	
    ////////////////////////////////////////
     void FixedUpdate()
    {
        

        Vector3 fixedVelocity = rgb2d.velocity;
        fixedVelocity.x *= 0.75f;
        if (grounded) { rgb2d.velocity = fixedVelocity; }

        float h = Input.GetAxis("Horizontal");
        if (rgb2d.CompareTag("Player"))
        {

           
           
            float limitedSpeed = Mathf.Clamp(rgb2d.velocity.x, -MaxSpeed, MaxSpeed);
            rgb2d.velocity = new Vector2(limitedSpeed, rgb2d.velocity.y);
            
        }
        


    }
    
}
