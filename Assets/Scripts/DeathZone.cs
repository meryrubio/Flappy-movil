using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathzone : MonoBehaviour
{

    public AudioClip deadClip; //audio de muerte

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        // Verifica si la colisión es con el esqueleto.
        if (collision.GetComponent<PlayerMovement>())
        {
            // Reinicia y limpia la escena de objetos y audios.
            GameManager.instance.ResetTime();// el contador se reinicia cada vez que el player muere

            AudioManager.instance.PlayAudio(deadClip, "deadSound"); //se reproduce sonido de muerte
        }
    }
}