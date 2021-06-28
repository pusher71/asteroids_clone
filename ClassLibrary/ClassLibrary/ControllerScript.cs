using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ClassLibrary
{
    public class ControllerScript : MonoBehaviour
    {
        public static ControllerScript instance; //экземпляр контроллера
        [SerializeField] private GameObject player; //что спавнить в начале игры
        [SerializeField] private GameObject emitter; //спавнер летающих опасностей

        //игровое меню
        [SerializeField] private GameObject menu; //контейнер
        [SerializeField] private Button buttonStart; //кнопка запуска
        [SerializeField] private Button buttonView; //кнопка переключения представления
        [SerializeField] private Text buttonViewText; //текст на ней
        [SerializeField] private Button buttonQuit; //кнопка выхода из игры

        //виджеты состояния игры
        [SerializeField] private GameObject bar; //контейнер
        [SerializeField] private Text barScore; //виджет очков в углу

        //сообщение о проигрыше
        [SerializeField] private GameObject gameOverWindow; //контейнер
        [SerializeField] private Button buttonAgain; //кнопка рестарта
        [SerializeField] private Button buttonBack; //кнопка возврата в меню
        [SerializeField] private Text textScore; //виджет очков

        public bool polygonView { get; private set; } //тип представления (false - спрайтовый, true - полигональный)
        int score; //текущее количество очков

        // Start is called before the first frame update
        void Start()
        {
            instance = this;
            polygonView = true;
            buttonStart.onClick.AddListener(delegate { startGame(); });
            buttonAgain.onClick.AddListener(delegate { startGame(); });
            buttonBack.onClick.AddListener(delegate
            {
                gameOverWindow.SetActive(false); //убрать сообщение
                menu.SetActive(true); //отобразить игровое меню
            });
            buttonView.onClick.AddListener(delegate
            {
                polygonView = !polygonView; //переключить представление и отразить это на тексте кнопки
                buttonViewText.text = "View: " + (polygonView ? "Polygonal" : "Sprites");
            });
            buttonQuit.onClick.AddListener(delegate { Application.Quit(); });
        }

        public void startGame()
        {
            //очистить поле от старых астероидов
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            foreach (GameObject asteroid in asteroids)
                Destroy(asteroid);

            //и от пуль
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject bullet in bullets)
                Destroy(bullet);

            menu.SetActive(false); //скрыть меню
            gameOverWindow.SetActive(false); //скрыть сообщение о проигрыше
            bar.SetActive(true); //отобразить состояние игры

            emitter.SetActive(true); //включить спавнер
            GetComponent<AudioSource>().Play(); //воспроизвести звук старта
            Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity); //заспавнить игрока на поле
            score = 0; //сбросить очки
            showScore(); //отобразить на экране
        }

        //показать меню и отключить астероиды
        public void stopGame()
        {
            emitter.SetActive(false); //отключить спавнер
            StartCoroutine(ExampleCoroutine());
        }

        //увеличить очки
        public void increaceScore(int increment)
        {
            score += increment;
            showScore();
        }

        //обновить очки в UI
        public void showScore()
        {
            barScore.text = "Score: " + score;
            textScore.text = "Your score: " + score;
        }

        IEnumerator ExampleCoroutine()
        {
            yield return new WaitForSeconds(2); //задержка
            bar.SetActive(false); //скрытие состояния игры
            gameOverWindow.SetActive(true); //отображение сообщения о проигрыше
        }
    }
}
