using UnityEngine;
using System.Collections;
public class Cubes : MonoBehaviour
{
    float durationTime = 10;
    bool isAlive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive && durationTime > 0)
        {
            StartCoroutine(InstantianteDelay());
        }
        else if (durationTime < 0)
        {
            StopCoroutine(InstantianteDelay());
            Destroy(gameObject);
        }
    }
    IEnumerator InstantianteDelay()
    {
        durationTime -= 1;
        isAlive = true;
        yield return new WaitForSeconds(0.5f);
        isAlive = false;
    }
}
