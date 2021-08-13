using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaUnLado : MonoBehaviour {

    private PlatformEffector2D efector;
    public float tiempoespera;



	// Use this for initialization
	void Start () {
        efector = GetComponent<PlatformEffector2D>();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.DownArrow))
        {
            tiempoespera = 0.5f;
        }


        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (tiempoespera<=0)
            {
                efector.rotationalOffset = 180f;
                tiempoespera = 0.5f;
            }
        }
        else
        {
            tiempoespera -= Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.Space))
        {
            efector.rotationalOffset = 0f;
        }


	}
}
