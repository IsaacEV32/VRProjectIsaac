using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //Se usa el ID de la escena (Escribirla en el inspector)
    [SerializeField] int sceneID;

    //Se cambia a la escena sugerida
    public void OnSceneChange()
    {
        SceneManager.LoadScene(sceneID);
    }
}
