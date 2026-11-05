using UnityEngine;

// Va en la Main Camera. Lanza un rayo hacia donde mira el jugador.
//  - Si mira una moneda (tag "Recolectable") y esta cerca, la recoge.
//  - Si mira el cofre (tag "Recuperador") durante "tiempoParaRecuperar" segundos, lo activa.
public class MiradaJugador : MonoBehaviour
{
    public float distanciaMaxima = 50f;
    public float distanciaRecoger = 3f;
    public float tiempoParaRecuperar = 2f;

    private float tiempoMirandoCofre = 0f;

    void Update()
    {
        bool mirandoCofre = false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distanciaMaxima))
        {
            if (hit.collider.CompareTag("Recolectable") && hit.distance <= distanciaRecoger)
            {
                hit.collider.GetComponent<Recolectable>().Recoger();
            }

            if (hit.collider.CompareTag("Recuperador"))
            {
                mirandoCofre = true;
                tiempoMirandoCofre = tiempoMirandoCofre + Time.deltaTime;

                if (tiempoMirandoCofre >= tiempoParaRecuperar)
                {
                    hit.collider.GetComponent<Recuperador>().Recuperar();
                    tiempoMirandoCofre = 0f;
                }
            }
        }

        // Si dejamos de mirar el cofre, el tiempo vuelve a empezar
        if (!mirandoCofre)
        {
            tiempoMirandoCofre = 0f;
        }
    }
}
