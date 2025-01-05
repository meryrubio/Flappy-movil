using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class GenerateParticle : MonoBehaviour
{
    public GameObject particlePrebab;
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE // SE EJECUTA ANTES DE COMPILAR EL CODIGO, solamente compilar el codigo necesario para pc o android

        //Pc
        if (Input.GetMouseButtonDown(0))
        {
            InstanceParticle(Input.mousePosition, Color.green);
        }

#elif UNITY_ANDROID

        //Android
        foreach (Touch touch in Input.touches) //por cada toque en todos los toques q ha habido en la pantalla
        {
            if(touch.phase == TouchPhase.Began)//primer toque en la pantalla
            {
                InstanceParticle(touch.position, Color.blue);
            }
        }
#endif
    }

    void InstanceParticle(Vector3 screenCoords, Color color)
    {
        //vector2 porque las coordenadas de pantalla estan en 2d pero lo convertimos en 3 porque sino z= 0 y sale en la camara
        screenCoords.z = 10;//para que se aleje de la camara (10 u)
        Vector3 gameCoords = _cam.ScreenToWorldPoint(screenCoords);//queremos trransformar las coordenadas de pantalla que queremos pasar al juego
        GameObject particleclone = Instantiate(particlePrebab, gameCoords, Quaternion.identity);
        particleclone.GetComponent<Renderer>().material.color = color;
        
    }
}
