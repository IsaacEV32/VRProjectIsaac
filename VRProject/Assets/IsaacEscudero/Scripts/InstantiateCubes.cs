using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;

public class InstantiateCubes : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject cubes;
    bool isInstantiate = false;
    float destinationOffsetRange;
    [SerializeField] Transform spawnPos;
    public static InstantiateCubes instance;
    bool isSpawning = true;
    float originalY;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destinationOffsetRange = 5;
        originalY = spawnPos.transform.position.y;
        StartCoroutine(InstantianteDelay());
    }
    public Transform GetPlayerPosition()
    {
        return player;
    }
    IEnumerator InstantianteDelay()
    {
        while (isSpawning)
        {
            float offset = Random.Range(-destinationOffsetRange, destinationOffsetRange);
            Vector3 direction = (new Vector3(Camera.main.transform.position.x + offset, Camera.main.transform.position.y + offset, Camera.main.transform.position.z + offset) - spawnPos.position).normalized;
            Vector3 cubePosition =
                new Vector3(spawnPos.position.x + direction.x, originalY + direction.y, spawnPos.position.z);
            GameObject c = Instantiate(cubes, cubePosition, Quaternion.identity);
            Vector3 playerdirection = player.transform.position - c.transform.position; 
            playerdirection.y = 0;
            c.transform.rotation = Quaternion.LookRotation(playerdirection);
            yield return new WaitForSeconds(2);

        }
    }
    public void DeactivateSpawner()
    {
        isSpawning = false;
        StopCoroutine(InstantianteDelay());
        this.enabled = false;
    }
}
