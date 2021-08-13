using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrar : MonoBehaviour {
    RaycastHit2D hit;
    public bool agarrado;
    public float distancia=2f;
    public Transform puntoDeAgarre;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (!agarrado)
            {
                //agarrar

                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distancia);
                if (hit.collider != null)
                {
                    agarrado = true;
                }
            }
            else
            {
                //lanzar


            }

        }
        if (agarrado)
        
            hit.collider.gameObject.transform.position = puntoDeAgarre.position;
        
      
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distancia);

    }




}
