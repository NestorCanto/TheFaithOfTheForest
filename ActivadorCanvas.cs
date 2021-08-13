using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorCanvas : MonoBehaviour {
    [SerializeField]
    private GameObject Canvas;

    private BoxCollider2D xd;


    private void Start()
    {
        xd = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Canvas.SetActive(true);
            xd.enabled = false;

        }
    }
}
