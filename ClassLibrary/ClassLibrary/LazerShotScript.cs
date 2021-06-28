using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassLibrary
{
    public class LazerShotScript : MonoBehaviour
    {
        [SerializeField] private float speed;

        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, speed), ForceMode.VelocityChange);
        }
    }
}
