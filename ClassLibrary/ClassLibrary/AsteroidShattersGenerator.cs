using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassLibrary
{
    public class AsteroidShattersGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject asteroid; //создаваемый астероид
        [SerializeField] private int createdCount; //количество создаваемых астероидов

        //ограничения на генерацию скорости
        public float minSpeed;
        public float maxSpeed;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < createdCount; i++)
            {
                //определить направление движения астероида
                float velocityX = Random.Range(-1f, 1f);
                float velocityZ = Random.Range(-1f, 1f);
                Vector3 velocity = new Vector3(velocityX, 0, velocityZ).normalized * Random.Range(minSpeed, maxSpeed);

                //создать астероид
                Instantiate(asteroid, transform.position, Quaternion.identity).GetComponent<Rigidbody>().velocity = velocity;
            }
        }
    }
}
