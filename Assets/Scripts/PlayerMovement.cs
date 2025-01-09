using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float flapForce;// fuerza del salto
    public float gravityScale = 1f; // escala de gravedad
    private Rigidbody rb;
    private Animator animator;
    public GameObject gameOverPanel;
    public AudioClip deadClip; //audio de muerte
    public AudioClip jumpClip; //audio de salto

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
        //AdDisplayManager.instance.ShowAd();
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
        AudioManager.instance.PlayAudio(jumpClip, "jumpSound");


       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Score>()) 
        {
            animator.SetBool("muerteofi", true);
            GameManager.instance.SetDeath(GameManager.instance.GetDeath() + 1);//cada vez que muero cuenta uno

            AudioManager.instance.PlayAudio(deadClip, "deadSound"); //se reproduce sonido de muerte

           
        }
        else
        {
            animator.SetBool("muerteofi", false);
        }
    }

    public void HandleDeath() {
        GameManager.instance.GameOver();
        gameOverPanel.SetActive(true);

        if (GameManager.instance.GetDeath() >= 3)
        {
            AdDisplayManager.instance.ShowAd(); //cuando muero 3 veces sale un anuncio
            GameManager.instance.SetDeath(0);
        }
    }
}
