using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassLibrary
{
    public class PlayerScript : MonoBehaviour
    {
        [SerializeField] private float speed; //линейная скорость
        [SerializeField] private float rotSpeed; //угловая скорость вращения в горизонтальной плоскости

        //ограничения на координату X
        [SerializeField] private float minX;
        [SerializeField] private float maxX;

        //ограничения на координату Z
        [SerializeField] private float minZ;
        [SerializeField] private float maxZ;

        [SerializeField] private GameObject lazerShot; //префаб лазерного снаряда
        [SerializeField] private GameObject lazerRay; //префаб лазерного луча
        [SerializeField] private Transform gunPosition; //позиция выпускания снаряда
        [SerializeField] private float shotDelay; //минимальное время между выстрелами снарядов
        [SerializeField] private float rayDelay; //минимальное время между выстрелами лазерных лучей
        float nextShotTime; //момент времени, когда можно будет выпустить снаряд
        float nextRayTime; //момент времени, когда можно будет выстрелить лазерным лучом

        Rigidbody playerShip;
        public GameObject createdOnExplode; //что создаётся при взрыве

        // Start is called before the first frame update
        void Start()
        {
            playerShip = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            //полёт со скоростью
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            playerShip.velocity = new Vector3(hor, 0, ver) * speed;

            //ограничение по границам
            float restX = Mathf.Clamp(playerShip.position.x, minX, maxX);
            float restZ = Mathf.Clamp(playerShip.position.z, minZ, maxZ);
            playerShip.position = new Vector3(restX, 0, restZ);

            //поворот
            float rot = Input.GetAxis("Rotation");
            playerShip.angularVelocity = new Vector3(0, rot, 0) * rotSpeed;

            //выпустить лазерный снаряд
            if (Input.GetButton("Fire1") && Time.time > nextShotTime)
            {
                Instantiate(lazerShot, gunPosition);
                nextShotTime = Time.time + shotDelay;
            }

            //выпустить лазерный луч
            if (Input.GetButton("Fire2") && Time.time > nextRayTime)
            {
                Instantiate(lazerRay, gunPosition);
                nextRayTime = Time.time + rayDelay;
            }

            //покинуть игру
            if (Input.GetKeyDown(KeyCode.Escape))
                explode();
        }

        public void explode()
        {
            Destroy(gameObject);
            Instantiate(createdOnExplode, transform.position, Quaternion.identity);
            ControllerScript.instance.stopGame(); //игрок проиграл
        }

        //получить значение готовности совершить выстрел лазерным лучом (0 - 1)
        public float getReadiness()
        {
            return 1 - (nextRayTime - Time.time) / rayDelay;
        }
    }
}
