using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float flapForce;// fuerza del salto
    public float gravityScale = 1f; // escala de gravedad
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Obtener el componente Animator
        //rb.gravityScale = gravityScale; // Aplicar la escala de gravedad
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE // Para PC
        // Detectar si se presiona la barra espaciadora o se hace clic con el ratón
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Flap();
        }
    }
#elif UNITY_ANDROID // Para Android
        // Detectar toques en la pantalla
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Flap();
            }
        }
#endif
    void Flap()
    {
        // Aplicar fuerza hacia arriba
        rb.velocity = Vector2.up * flapForce; // Reiniciar la velocidad vertical


        //Activar la animación de salto
        animator.SetBool("jump", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.GameOver();
    }
}
