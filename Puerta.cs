using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Puerta : MonoBehaviour {



    private BoxCollider2D activar;

    public GameObject Swi;

    public GameObject PAbierta;
    public GameObject Pcerrada;


	// Use this for initialization
	void Start () {
        activar = GetComponent<BoxCollider2D>();
        activar.enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite= Pcerrada.GetComponent<SpriteRenderer>().sprite;



    }
	
	

    public int NivelaCargar;
    private void Update()
    {
        Abrir();
        
    }


    void Abrir()
    {
        if(Swi.GetComponent<Switch>().IsOn == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = PAbierta.GetComponent<SpriteRenderer>().sprite;
            activar.enabled = false;
            

        }


    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene(NivelaCargar);

           
        }

    }
}
