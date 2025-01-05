using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObjectPull pipePool; // Referencia al pool de tuber�as
    public float spawnRate = 2f; // Frecuencia de aparici�n de tuber�as
    public float heightOffset = 3f; // Desplazamiento de altura para las tuber�as
    public float spawnXPosition = 10f; // Posici�n X donde aparecer�n las tuber�as

    private void Start()
    {
        InvokeRepeating("SpawnPipe", 0f, spawnRate); // Llamar a SpawnPipe repetidamente
    }

    void SpawnPipe()
    {
        GameObject pipe = pipePool.GimmeInactiveGameObject(); // Obtener una tuber�a del pool
        if (pipe != null)
        {
            float randomHeight = Random.Range(-heightOffset, heightOffset); // Altura aleatoria
            float upperPipeY = randomHeight + (pipe.transform.localScale.y / 2); // Posici�n Y de la tuber�a superior
            float lowerPipeY = randomHeight - (pipe.transform.localScale.y / 2); // Posici�n Y de la tuber�a inferior

            // Establecer la posici�n de las tuber�as
            pipe.transform.position = new Vector3(spawnXPosition, upperPipeY, 0);
            pipe.SetActive(true); // Activar la tuber�a

            // Crear la tuber�a inferior
            GameObject lowerPipe = pipePool.GimmeInactiveGameObject(); // Obtener otra tuber�a del pool
            if (lowerPipe != null)
            {
                lowerPipe.transform.position = new Vector3(spawnXPosition, lowerPipeY, 0);
                lowerPipe.SetActive(true); // Activar la tuber�a inferior
            }
        }
    }
}
