using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClassLibrary;

public class PolygonalSpriteView : MonoBehaviour
{
    [SerializeField] protected GameObject polygonView; //полигональное представление
    [SerializeField] protected GameObject spriteView; //спрайтовое представление

    // Start is called before the first frame update
    void Start()
    {
        //отобразить одно из представлений
        polygonView.SetActive(ControllerScript.instance.polygonView);
        spriteView.SetActive(!ControllerScript.instance.polygonView);
    }
}
