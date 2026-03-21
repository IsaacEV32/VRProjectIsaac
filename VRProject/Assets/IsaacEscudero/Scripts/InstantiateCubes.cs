using System.Collections;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject cubes;
    bool isInstantiate = false;
    float destinationOffsetRange;
    [SerializeField] Transform spawnPos;
    public static InstantiateCubes instance;

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
        StartCoroutine(InstantianteDelay());
    }
    public Transform GetPlayerPosition()
    {
        return player;
    }
    IEnumerator InstantianteDelay()
    {
        while (true)
        {
            float offset = Random.Range(-destinationOffsetRange, destinationOffsetRange);
            Vector3 direction = (new Vector3(Camera.main.transform.position.x + offset, Camera.main.transform.position.y + offset, Camera.main.transform.position.z + offset) - spawnPos.position).normalized;
            Vector3 cubePosition =
                new Vector3(spawnPos.position.x + direction.x, direction.y + 1, spawnPos.position.z);
            GameObject c = Instantiate(cubes, cubePosition, Quaternion.identity);
            c.transform.LookAt(player);
            yield return new WaitForSeconds(2);

        }
    }
}
