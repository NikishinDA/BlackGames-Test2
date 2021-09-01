using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayWallScript : MonoBehaviour
{
    public string color;//цвет стены
    public float forceMultipier = 5;//множетель и направление силы отскока
    public Text scoreText;//текст счёта
    public GameObject controllerObject;//объект с управдением
    public GameObject gameManagerObject;//объект менеджера

    private int score = 0;//счёт
    private ContrillerScript contrillerScript;//скрипт управления
    private GameManagerScript gmScript;//скрипт менеджера
    private void Start()
    {
        contrillerScript = controllerObject.GetComponent<ContrillerScript>();
        gmScript = gameManagerObject.GetComponent<GameManagerScript>();

    }

    private void OnTriggerEnter(Collider other)//при попадании в тригер объекта
    {
        if (other.CompareTag(color))//если он того же цвета
        {
            Destroy(other.gameObject);//уничтожить
            score++;//прибавить счёт
            scoreText.text = score.ToString();//вывести на экран
            gmScript.cubeDestoyed();//сообщить менеджеру
        }
        else//если другого цвета
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(1,0) * forceMultipier;//оттянуть куб
            contrillerScript.Reject();//отобрать управление
        }
    }
}
