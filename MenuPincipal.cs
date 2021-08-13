using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPincipal : MonoBehaviour {
    

    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
	

    public void SalirDelJuego()
    {
        Application.Quit();
    }




    public void MenuPincipaL()
    {
        SceneManager.LoadScene(0);

    }

    ////// NIVELES A CARGAR EN EL MENU

    public void nivel1()
    {
        SceneManager.LoadScene(1);

    }
    public void nivel2()
    {
        SceneManager.LoadScene(2);

    }
    public void nivel3()
    {
        SceneManager.LoadScene(4);

    }
    public void nivel4()
    {
        SceneManager.LoadScene(5);

    }

    public void Creditos()
    {
        SceneManager.LoadScene(6);

    }



}
