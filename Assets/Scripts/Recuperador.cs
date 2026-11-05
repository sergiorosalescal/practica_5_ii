using UnityEngine;

// PUNTO 3. Va en el cofre (notificador del patron observador).
// Cuando MiradaJugador lo activa, avisa a todas las monedas suscritas.
public class Recuperador : MonoBehaviour
{
    public delegate void mensaje();
    public static event mensaje OnRecuperar;

    public void Recuperar()
    {
        OnRecuperar();
    }
}
