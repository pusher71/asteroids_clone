using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ClassLibrary
{
    public class BarReadinessScript : MonoBehaviour
    {
        [SerializeField] private PlayerScript player; //привязанный игрок
        private Image barReadiness; //виджет готовности совершить выстрел лазерным лучом

        // Start is called before the first frame update
        void Start()
        {
            barReadiness = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            barReadiness.fillAmount = player.getReadiness(); //обновить виджет готовности
            barReadiness.color = barReadiness.fillAmount == 1 ? Color.green : Color.yellow; //и покрасить его
        }
    }
}
