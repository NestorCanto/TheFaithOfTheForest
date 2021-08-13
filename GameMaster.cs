using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameMaster : MonoBehaviour {
    public int points;
    
    public int NumSemillas;
   

    

    public Text pointsText;
    //public Text InputText;

    

   void Update()
    {
        pointsText.text= ("Semillas: "+points+" /"+NumSemillas);

       
    }
}
