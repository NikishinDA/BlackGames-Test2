using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private int cubeNumber = 5;//число кубов на полу

    public GameObject restartUI;//UI для рестарта (деактивирован)

    void Update()
    {
        if (cubeNumber == 0)//если больше кубов нет
        {
            restartUI.SetActive(true);//показать рестарт кнопку
        }
    }

    public void cubeDestoyed()//когда куб уничтожается
    {
        cubeNumber--;//уменьшить число кубов
    }
}
