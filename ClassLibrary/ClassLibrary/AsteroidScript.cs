using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassLibrary
{
    public class AsteroidScript : FlyingDanger
    {
        //ограничения на генерацию размера
        [SerializeField] private float minSize;
        [SerializeField] private float maxSize;

        [SerializeField] private float rotSpeed; //скорость вращения (при полигональном представлении)
        float size; //текущий размер

        // Start is called before the first frame update
        void Start()
        {
            size = Random.Range(minSize, maxSize);
            transform.localScale *= size;

            //полигональное представление вращается
            if (ControllerScript.instance.polygonView)
            {
                Rigidbody body = GetComponent<Rigidbody>();
                body.angularVelocity = Random.insideUnitSphere * rotSpeed;
            }
        }
    }
}
