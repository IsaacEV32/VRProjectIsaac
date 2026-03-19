using TMPro;
using UnityEngine;

public class SwordControl : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cubes c))
        {
            Puntuation.instance.SetPuntuation();
            c.DestroyCube();
        }
    }
}
