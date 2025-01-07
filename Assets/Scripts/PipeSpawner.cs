using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;

    public float heightRange;

    public float maxTime = 1.75f;

    private float timer;
    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
    }

    public void SpawnPipe()
    {
        Vector3 spawnposition = transform.position + new Vector3(0,Random.Range(-heightRange,heightRange));//poder instanciar la tuberia con un rango de altura

        GameObject newPipe; //intanciar nuevo tipo de gameobject new pipe para instanciarlos

        newPipe = Instantiate(pipePrefab, spawnposition, Quaternion.identity);// la asignamos en una variable para poder luego destruirlas

        Destroy(newPipe, 15f);
    }
}
