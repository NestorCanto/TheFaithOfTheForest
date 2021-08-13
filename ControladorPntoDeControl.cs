using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPntoDeControl : MonoBehaviour {
    public Sprite Banderaamarilla;
    public Sprite BanderaRoja;
    public bool PntoAlcanzado;

    private SpriteRenderer spr;

	// Use this for initialization
	void Start () {
        spr = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    ///////para cambiear el coolor de la bandera cuando el player lo toca
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="Player") {
            spr.sprite = BanderaRoja;
            PntoAlcanzado = true;

        }
        
    }
}
