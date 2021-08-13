using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CargadorDeNivel : MonoBehaviour {
    public GameObject PantallaDeCarga;
    public Slider slider;
    public Text TextoProgreso;


    public void LoadLevel(int NivelaCargar)
    {
        StartCoroutine(CargarNivel(NivelaCargar));

        
    }
	

    IEnumerator CargarNivel(int NivelaCargar)    
    {
        AsyncOperation operacion = SceneManager.LoadSceneAsync(NivelaCargar);

        PantallaDeCarga.SetActive(true);
        while (!operacion.isDone)
        {
            float progreso = Mathf.Clamp01(operacion.progress / .9f);
            slider.value = progreso;
            TextoProgreso.text = progreso * 100f + "%";
            yield return null;
        }
    }
}
