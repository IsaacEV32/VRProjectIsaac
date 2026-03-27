using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    bool isDoubleSableActive = true;
    [SerializeField] GameObject leftSable;
    [SerializeField] Text textForSableOption;
    private void Awake()
    {
        textForSableOption.text = "Modo 2 sables";
        Puntuation.instance.SetMaxPuntuation(10);
    }
    public void ChangeSableOption()
    {
        if (isDoubleSableActive)
        {
            leftSable.SetActive(false);
            textForSableOption.text = "Modo 1 sable";
            isDoubleSableActive = false;
        }
        else if (!isDoubleSableActive)
        {
            leftSable.SetActive(true);
            textForSableOption.text = "Modo 2 sables";
            isDoubleSableActive = true;
        }

    }
    public void ChangeMaxPoints(int value)
    {
        switch (value)
        {
            case 0:
                Puntuation.instance.SetMaxPuntuation(10);
                break;
            case 1:
                Puntuation.instance.SetMaxPuntuation(20);
                break;
            case 2:
                Puntuation.instance.SetMaxPuntuation(30);
                break;
        }
    }
}
