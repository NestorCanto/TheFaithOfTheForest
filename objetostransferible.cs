using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class objetostransferible : MonoBehaviour {
    

    public static objetostransferible Objetostransferible;

    private void Awake()
    {
        if (Objetostransferible==null)
        {
            Objetostransferible = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Objetostransferible!=this)
        {
            Destroy(gameObject);
           
        }
            
        
        

    }
   

}
