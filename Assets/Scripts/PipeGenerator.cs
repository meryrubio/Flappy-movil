using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObjectPull pipePool; // Referencia al pool de tuberías
    public float spawnRate = 2f; // Frecuencia de aparición de tuberías
    public float heightOffset = 3f; // Desplazamiento de altura para las tuberías
    public float spawnXPosition = 10f; // Posición X donde aparecerán las tuberías

    private void Start()
    {
        InvokeRepeating("SpawnPipe", 0f, spawnRate); // Llamar a SpawnPipe repetidamente
    }

    void SpawnPipe()
    {
        GameObject pipe = pipePool.GimmeInactiveGameObject(); // Obtener una tubería del pool
        if (pipe != null)
        {
            float randomHeight = Random.Range(-heightOffset, heightOffset); // Altura aleatoria
            float upperPipeY = randomHeight + (pipe.transform.localScale.y / 2); // Posición Y de la tubería superior
            float lowerPipeY = randomHeight - (pipe.transform.localScale.y / 2); // Posición Y de la tubería inferior

            // Establecer la posición de las tuberías
            pipe.transform.position = new Vector3(spawnXPosition, upperPipeY, 0);
            pipe.SetActive(true); // Activar la tubería

            // Crear la tubería inferior
            GameObject lowerPipe = pipePool.GimmeInactiveGameObject(); // Obtener otra tubería del pool
            if (lowerPipe != null)
            {
                lowerPipe.transform.position = new Vector3(spawnXPosition, lowerPipeY, 0);
                lowerPipe.SetActive(true); // Activar la tubería inferior
            }
        }
    }
}
