using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondo : MonoBehaviour {

    public float Speed = 1.5f;
    Vector2 FondoPos;

    //////para  seguiminto
    public GameObject follow;
    public Vector2 minCamPos, maxCamPos;
    public float smoothTime;

    private Vector2 velocity;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveFondo();
	}
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(follow.transform.position.x, follow.transform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(follow.transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            transform.position.z);
    }


    //mover fondo
    private void MoveFondo()
    {
        FondoPos += new Vector2( Time.deltaTime * Speed,0);

        GetComponent<Renderer>().material.mainTextureOffset = FondoPos;
    }

}
