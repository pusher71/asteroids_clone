using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassLibrary
{
    public class FlyingDanger : MonoBehaviour
    {
        [SerializeField] private GameObject createdOnExplode; //что создаётся при взрыве
        [SerializeField] private int award; //сколько очков платится за уничтожение

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Asteroid" && other.tag != "Boundary")
            {
                if (other.tag == "Player") //попался игрок
                    other.GetComponent<PlayerScript>().explode(); //игрок взрывается
                else //точно снаряд или лазер попал
                    ControllerScript.instance.increaceScore(award); //увеличить очки

                Destroy(other.gameObject); //попавшийся объект удаляется
                explode(); //текущий объект взрывается
            }
        }

        public void explode()
        {
            Destroy(gameObject);
            Instantiate(createdOnExplode, transform.position, Quaternion.identity);
        }
    }
}
