using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;
public class Cubes : MonoBehaviour
{
    [SerializeField] float durationTime = 3;
    bool isAlive = false;
    float cubeSpeed = 4;
    Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.SetActive(true);
        player = InstantiateCubes.instance.GetPlayerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * cubeSpeed * Time.deltaTime;
        if (!isAlive && durationTime > 0)
        {
            StartCoroutine(InstantianteDelay());
        }
        else if (durationTime <= 0)
        {
            StopCoroutine(InstantianteDelay());
            DestroyCube();
        }
    }
    IEnumerator InstantianteDelay()
    {
        durationTime -= Time.deltaTime;
        isAlive = true;
        yield return new WaitForSeconds(0.05f);
        isAlive = false;
    }
    public void DestroyCube()
    {
        Destroy(this.gameObject);
    }
}
