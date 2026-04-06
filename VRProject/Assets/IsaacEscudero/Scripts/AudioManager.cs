using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField]AudioSource audioSource;
    [SerializeField]AudioClip buttonClick;
    [SerializeField] AudioClip wrongCut;
    [SerializeField] AudioClip goodCut;
    [SerializeField] AudioClip bomb;
    public static AudioManager instance;
    [SerializeField] GameObject Menu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    public IEnumerator PlayMenuButtonSound()
    {
        audioSource.PlayOneShot(buttonClick);
        yield return new WaitUntil(() => !audioSource.isPlaying);
        Debug.Log("Termino el audio");
    }
    public IEnumerator PlayExitMenuButtonSound()
    {
        audioSource.PlayOneShot(buttonClick);
        yield return new WaitUntil(() => !audioSource.isPlaying);
        DontDestroyOnLoad(Menu);
        DontDestroyOnLoad(this);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public IEnumerator PlayExitGameButtonSound()
    {
        audioSource.PlayOneShot(buttonClick);
        yield return new WaitUntil(() => !audioSource.isPlaying);
        Application.Quit();
    }
    public void PlayGoodCutSound()
    {
        audioSource.PlayOneShot(goodCut);
    }
    public void PlayWrongCutSound()
    {
        audioSource.PlayOneShot(wrongCut);
    }
    public void PlayBombSound()
    {
        audioSource.PlayOneShot(buttonClick);
    }
}
