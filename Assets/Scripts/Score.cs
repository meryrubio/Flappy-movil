using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            GameManager.instance.IncreaseScore(1); // llamamos al gamemanager para que el metodo de increase score pueda sumar los puntos de uno en uno (1) cundo coge una pocion.
            
        }
    }
}
