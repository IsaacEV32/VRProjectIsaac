using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] int sceneID;
    public void OnSceneChange()
    {
        SceneManager.LoadScene(sceneID);
    }
}
