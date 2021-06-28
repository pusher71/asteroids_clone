using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassLibrary
{
    public class UFOScript : FlyingDanger
    {
        [SerializeField] private float speed; //скорость погони

        private GameObject target; //цель преследования
        private Rigidbody rb;

        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player");
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (target != null) //если цель пока не убита
                rb.velocity = (target.transform.position - transform.position).normalized * speed; //погнаться
        }
    }
}
