using TMPro;
using UnityEngine;

public class Puntuation : MonoBehaviour
{
    [SerializeField] TMP_Text puntuation;
    int points = 0;

    public static Puntuation instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntuation.text = points.ToString();
    }
    public int GetPuntuation()
    {
        return points;
    }
    public void SetPuntuation()
    {
        if (points < 20)
        {
            points++;
            puntuation.text = points.ToString();
        }
        else
        {
            puntuation.text = "FIN";
            InstantiateCubes.instance.DeactivateSpawner();
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
