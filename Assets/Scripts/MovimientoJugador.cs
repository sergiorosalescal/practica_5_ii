using UnityEngine;

// Va en el Player. Necesita Rigidbody y Capsule Collider.
// Si la camara apunta al suelo (objeto con tag "Suelo"), el jugador avanza.
// Si apunta a cualquier otra cosa, se queda quieto (pero puede girar la cabeza).
public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 3f;
    public float distanciaMirarSuelo = 10f;

    private Rigidbody rb;
    private Transform camara;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camara = Camera.main.transform;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(camara.position, camara.forward, out hit, distanciaMirarSuelo))
        {
            if (hit.collider.CompareTag("Suelo"))
            {
                Vector3 direccion = camara.forward;
                direccion.y = 0;
                direccion.Normalize();

                Vector3 nuevaPosicion = rb.position + direccion * velocidad * Time.fixedDeltaTime;
                rb.MovePosition(nuevaPosicion);
            }
        }
        Debug.DrawRay(camara.position, camara.forward * distanciaMirarSuelo, Color.red);
    }
}
