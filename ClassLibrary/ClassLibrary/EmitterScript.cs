using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassLibrary
{
    public class EmitterScript : MonoBehaviour
    {
        [SerializeField] private GameObject[] created; //набор объектов для спавна

        //ограничения на задержку между созданием объектов
        [SerializeField] private float minDelay;
        [SerializeField] private float maxDelay;

        //ограничения на генерацию скорости
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;

        float scale; //ширина излучателя
        float nextTime; //момент создания следующего объекта

        // Start is called before the first frame update
        void Start()
        {
            scale = transform.localScale.x;
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time > nextTime)
            {
                Instantiate(created[Random.Range(0, created.Length)], new Vector3(Random.Range(-scale / 2, scale / 2), 0, transform.position.z), Quaternion.identity)
                    .GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -Random.Range(minSpeed, maxSpeed));
                nextTime = Time.time + Random.Range(minDelay, maxDelay);
            }
        }
    }
}
