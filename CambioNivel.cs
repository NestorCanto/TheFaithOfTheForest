using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour {
    public GameMaster gm1;
    private BoxCollider2D box;

    public GameObject Carga;
    public GameObject Juego;
    public int NivelaCargar;
    public int ptsRequeridos;



     void Start()
    {
        box = GetComponent<BoxCollider2D>();
        box.enabled = true;
        Carga.SetActive(false);
        Juego.SetActive(true);

    }

     void Update()
    {
        if (gm1.points== ptsRequeridos|| gm1.points>ptsRequeridos)
        {
            box.enabled = false;
            
           
        }


        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    box.enabled = false;
        //}
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Juego.SetActive(false);
            Carga.SetActive(true);
            SceneManager.LoadScene(NivelaCargar);
        }
    }

   

    
     
}
