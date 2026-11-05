using UnityEngine;
using TMPro;

// Va en el texto del marcador. Esta suscrito al evento de las monedas.
public class Marcador : MonoBehaviour
{
    private TMP_Text texto;
    private int puntuacion = 0;

    void Start()
    {
        texto = GetComponent<TMP_Text>();
        texto.text = "Puntos: " + puntuacion;
        Recolectable.OnRecogido += Sumar;
    }

    void OnDestroy()
    {
        Recolectable.OnRecogido -= Sumar;
    }

    void Sumar(int puntos)
    {
        puntuacion = puntuacion + puntos;
        texto.text = "Puntos: " + puntuacion;
    }
}
