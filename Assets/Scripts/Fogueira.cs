using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogueira : MonoBehaviour
{
    public bool isLit;
    public float fuel;
    
    private MeshRenderer lenhador;
    public Material unLitMat;
    public Material fireMat;

    void Start()
    {
        lenhador = gameObject.GetComponent<MeshRenderer>();
        fuel = 100;
    }

    void Update()
    {
        fuel += -Time.deltaTime;

        if (fuel <= 0)
        {
            isLit = false;
        }
        else
        {
            isLit = true;
        }

        if (isLit == false)
        {
            UnLitFireplace();
        }
        else 
        {
            LitFireplace();
        }
    }

    void LitFireplace()
    {
        lenhador.material = fireMat;
    }

    void UnLitFireplace()
    {
       lenhador.material = unLitMat;
    }
}
