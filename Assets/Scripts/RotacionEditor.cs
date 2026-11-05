using UnityEngine;
using UnityEngine.InputSystem;

// SOLO PARA PROBAR EN EL EDITOR (en el movil la camara gira con la cabeza).
// Va en la Main Camera. Flechas izquierda/derecha giran, arriba/abajo miran arriba/abajo.
public class RotacionEditor : MonoBehaviour
{
    public float velocidadGiro = 60f;

    void Update()
    {
        if (Application.isEditor)
        {
            float horizontal = 0f;
            float vertical = 0f;

            if (Keyboard.current.rightArrowKey.isPressed) horizontal = 1f;
            if (Keyboard.current.leftArrowKey.isPressed) horizontal = -1f;
            if (Keyboard.current.upArrowKey.isPressed) vertical = 1f;
            if (Keyboard.current.downArrowKey.isPressed) vertical = -1f;

            transform.Rotate(Vector3.up * horizontal * velocidadGiro * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.right * -vertical * velocidadGiro * Time.deltaTime);
        }
    }
}
