using System.Collections;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject cubes;
    bool isInstantiate = false;
    float destinationOffsetRange;
    [SerializeField]Transform spawnPos;
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
    public Transform GetPlayerPosition()
    {
        return player;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destinationOffsetRange = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Random.Range(-destinationOffsetRange, destinationOffsetRange);
        Vector3 direction = (new Vector3(Camera.main.transform.position.x + offset, Camera.main.transform.position.y + offset, Camera.main.transform.position.z + offset) - spawnPos.position).normalized;
        if (!isInstantiate)
        {
            Vector3 cubePosition = 
                new Vector3(spawnPos.position.x * direction.x, spawnPos.position.y * direction.y, spawnPos.position.z * direction.z);
            GameObject c = Instantiate(cubes, cubePosition, Quaternion.identity);
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
