using TMPro;
using UnityEngine;

public class SwordControl : MonoBehaviour
{
    [SerializeField] GameObject leftSable;
    //Sirve comprobar si se ha activado el modo dos espadas o una espada
    private void Start()
    {
        if (leftSable != null)
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

    }
    private void OnCollisionEnter(Collision collision)
    {
        //Si entra en colision con un objeto que tenga el script Cubes 
        if (collision.gameObject.TryGetComponent(out Cubes c))
        {
            if (c as HardModeCubes)
            {
                //Se llama a la funcion para actualizar la puntuacion
                Puntuation.instance.SetPuntuationCubosModoDificil();
                //Se destruye el cubo
                c.DestroyCube();
            }
            else
            {
                //Se llama a la funcion para actualizar la puntuacion
                Puntuation.instance.SetPuntuationCubosNormales();
                //Se destruye el cubo
                c.DestroyCube();
            }
            
        }
        
    }
}
