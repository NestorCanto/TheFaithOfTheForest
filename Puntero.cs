using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntero : MonoBehaviour {

    



    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
        Vector2 PosPuntero = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = PosPuntero;

       
	}
}
