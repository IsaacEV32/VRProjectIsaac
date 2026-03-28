using TMPro;
using UnityEngine;

public class SwordControl : MonoBehaviour
{
    [SerializeField] GameObject leftSable;
    private void Start()
    {
        if (!UI.instance.CheckSableMode())
        {
            leftSable.SetActive(false);
        }
        else
        {
            leftSable.SetActive(true);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        //Si entra en colision con un objeto que tenga el script Cubes 
        if (collision.gameObject.TryGetComponent(out Cubes c))
        {
            //Se llama a la funcion para actualizar la puntuacion
            Puntuation.instance.SetPuntuation();
            //Se destruye el cubo
            c.DestroyCube();
        }
    }
}
