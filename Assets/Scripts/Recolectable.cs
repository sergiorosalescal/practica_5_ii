using UnityEngine;

// Va en cada moneda. Gira sobre si misma y desaparece al recogerla.
// Esta suscrita al evento del cofre: cuando salta, vuela hacia el jugador.
public class Recolectable : MonoBehaviour
{
    public int puntos = 1;
    public float velocidadGiro = 90f;
    public float velocidadHaciaJugador = 6f;

    public delegate void mensaje(int puntos);
    public static event mensaje OnRecogido;

    private Transform jugador;
    private bool yendoHaciaJugador = false;

    void Start()
    {
        jugador = Camera.main.transform;
        Recuperador.OnRecuperar += IrHaciaJugador;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * velocidadGiro * Time.deltaTime, Space.World);

        if (yendoHaciaJugador)
        {
            transform.position = Vector3.MoveTowards(transform.position, jugador.position,
                                                     velocidadHaciaJugador * Time.deltaTime);

            if (Vector3.Distance(transform.position, jugador.position) < 1f)
            {
                Recoger();
            }
        }
    }

    public void Recoger()
    {
        OnRecogido(puntos);
        gameObject.SetActive(false);
    }

    // Al terminar el juego nos damos de baja del evento (ver explicacion)
    void OnDestroy()
    {
        Recuperador.OnRecuperar -= IrHaciaJugador;
    }

    void IrHaciaJugador()
    {
        yendoHaciaJugador = true;
    }
}
