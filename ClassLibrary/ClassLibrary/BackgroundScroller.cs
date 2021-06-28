﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassLibrary
{
    public class BackgroundScroller : MonoBehaviour
    {
        Vector3 startPosition;
        [SerializeField] private float speed;

        // Start is called before the first frame update
        void Start()
        {
            startPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            float move = Mathf.Repeat(Time.time * speed, 140);
            transform.position = startPosition + new Vector3(0, 0, -move);
        }
    }
}
