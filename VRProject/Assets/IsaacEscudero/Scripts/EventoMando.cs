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

    private void OnMenuButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
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
    public void Continue()
    {
        UI.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
