using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordControl : MonoBehaviour
{
    int layer = 8;
    LayerMask cubeFlechaLayer;
    [SerializeField] GameObject leftSable;
    //Sirve comprobar si se ha activado el modo dos espadas o una espada
    private void Start()
    {
        cubeFlechaLayer = 1 << layer;
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
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.TryGetComponent(out DetectorSideCube dC))
        {
            Debug.Log("Me golpeaste");
            //Se llama a la funcion para actualizar la puntuacion
            Puntuation.instance.SetPuntuationCubosNormales();
            //Se destruye el cubo
            dC.gameObject.GetComponentInParent<CubesFlechas>().DestroyCube();

        }
        //Si entra en colision con un objeto que tenga el script Cubes 
        if (collision.gameObject.TryGetComponent(out Cubes c))
        {
            if (c as CubesFlechas)
            {
                c.DestroyCube();
            }
            if (c as HardModeCubes)
            {
                //Se llama a la funcion para actualizar la puntuacion
                Puntuation.instance.SetPuntuationCubosModoDificil();
                //Se destruye el cubo
                c.DestroyCube();
            }
            else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                //Se llama a la funcion para actualizar la puntuacion
                Puntuation.instance.SetPuntuationCubosNormales();
                //Se destruye el cubo
                c.DestroyCube();
            }

        }

    }
}
