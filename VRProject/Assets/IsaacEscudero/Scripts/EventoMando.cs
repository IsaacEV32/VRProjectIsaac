using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EventoMando : MonoBehaviour
{
    [SerializeField] private InputActionReference menuActionReference;
    [SerializeField] GameObject UI;
    private void Awake()
    {
        UI.SetActive(false);
    }
    private void OnEnable()
    {
        // Suscribirse al evento 'performed' (cuando se pulsa el botón)
        menuActionReference.action.performed += OnMenuButtonPressed;
    }

    private void OnDisable()
    {
        // Desuscribirse para evitar errores de memoria
        menuActionReference.action.performed -= OnMenuButtonPressed;
    }
    //Se activara al dar el boton de menu del mando izquierdo de VR
    private void OnMenuButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Se activara o desactivara la UI y el tiempo dependiendo del estado de la UI 
            if (UI.activeSelf)
            {
                UI.SetActive(false);
                Time.timeScale = 1.0f;
            }
            else
            {
                UI.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }
    //Volvera a activar el tiempo y desactivara la UI
    public void Continue()
    {
        StartCoroutine(AudioManager.instance.PlayMenuButtonSound());
        UI.SetActive(false);
        Time.timeScale = 1.0f;
    }
    //Se usa para volver a la escena de MenuVR
    public void ExitToMenu()
    {
        StartCoroutine(AudioManager.instance.PlayExitMenuButtonSound());
    }
    //Se usa para salir del juego
    public void ExitGame()
    {
        StartCoroutine(AudioManager.instance.PlayExitGameButtonSound());
    }
}
