using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePausa : MonoBehaviour {
    

    public static bool JuegoPausado = false;

    public GameObject MenuDePausaUI;

    [SerializeField]
    private int NivelAReiniciar;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoPausado)
            {
                Resumir();
            }
            else
            {
                Pausar();
            }

        }
	}


    //metos de resumir y pausar....
    public void Resumir()
    {
        MenuDePausaUI.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
    }

    void Pausar()
    {
        MenuDePausaUI.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
    }

    public void CargarMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void reiniciar()
    {

        SceneManager.LoadScene(NivelAReiniciar);
        
        Time.timeScale = 1f;
        
    }
}
