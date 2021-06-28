using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassLibrary
{
    public class LazerRayScript : MonoBehaviour
    {
        [SerializeField] private float lifeTime; //время жизни лазера

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(LazerOff());
        }

        IEnumerator LazerOff()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }
    }
}
