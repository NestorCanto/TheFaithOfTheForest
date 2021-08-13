using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarSuelo1 : MonoBehaviour {
    private PlayerController player;

	
    
    // Use this for initialization
	void Start () {
        player = GetComponent<PlayerController>(); 
         
	}
    private void OnCollisionStay2D(Collision2D col)
    {
        player.grounded = true;
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        player.grounded = false;
    }

}
