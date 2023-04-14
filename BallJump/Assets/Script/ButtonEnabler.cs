using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnabler : MonoBehaviour
{
    [SerializeField] int nivel = 0;
    void Awake()
    {
        int superado = PlayerPrefs.GetInt("Nivel Superado" + (nivel-1).ToString(), 0);
        GetComponent<Button>().interactable = superado == 1 ? true : false;
    }
}
