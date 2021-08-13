using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour {
    //se creó un objeto de stats pata poder acceder al valor máximo de vida y asi poder aumentarlo
    private Stats vida;


    
    //siempre es de 0 a 1

    private float CantDeLlenado;

    [SerializeField]
    private float VelDeDrenado;

    [SerializeField]
    private Image Contenido;


    [SerializeField]
    private Text TextoDelValor;

    public float ValorMax { get; set; }

    public float Valor
    {
        set
        {
            string[] tmp = TextoDelValor.text.Split(':');
            TextoDelValor.text = tmp[0] + ": " + value;
            CantDeLlenado = Map(value, 0, ValorMax, 0, 1);
        }

    }


    // Use this for initialization
    void Start() {
        Valor = vida.MaxVal;

    }

    //Se actualiza por framses en el juego.
    void Update()
    {
        ManejarBarra();
    }



    private void ManejarBarra()
    {
        if (CantDeLlenado!=Contenido.fillAmount)
        {
            Contenido.fillAmount = Mathf.Lerp(Contenido.fillAmount,CantDeLlenado,Time.deltaTime*VelDeDrenado);
        }        
    }

    private float Map( float valor,float inMin, float inMax,float outMin, float outMax)
    {
        return (valor - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;          
    }
    
    
    
  
	
}
