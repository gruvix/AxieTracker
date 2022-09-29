using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initializer : MonoBehaviour
{
    public GameObject panelOpciones;
    // Start is called before the first frame update
    void Start()
    {
        panelOpciones.gameObject.SetActive(true);
    }
}
