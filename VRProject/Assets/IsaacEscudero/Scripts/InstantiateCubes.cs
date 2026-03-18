using System.Collections;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject cubes;
    bool isInstantiate = false;
    float destinationOffsetRange;
    Vector3 spawnPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destinationOffsetRange = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Random.Range(-destinationOffsetRange, destinationOffsetRange);
        Vector3 direction = (new Vector3(Camera.main.transform.position.x + offset, Camera.main.transform.position.y + offset, Camera.main.transform.position.z + offset) - spawnPos).normalized;
        if (!isInstantiate)
        {
            Instantiate(cubes, direction, Quaternion.identity);
            StartCoroutine(InstantianteDelay());
        }
    }
    IEnumerator InstantianteDelay()
    {
        isInstantiate = true;
        yield return new WaitForSeconds(2);
        isInstantiate = false;
    }
}
