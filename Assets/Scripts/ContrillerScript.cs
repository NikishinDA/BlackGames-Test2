using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrillerScript : MonoBehaviour
{
    private GameObject go;//управляемый объект
    private Vector3 screenSpace;//проецируемая позиция объекта на экран
    private bool isDrag = false;//тащим ли объект
    private bool lostControl = false;//потеряли ли управление
    private float timeout;//время до того, как сможем снова тащить куб
    public float cooldown = 2.0f;


    // Use this for initialization
    void Start()
    {
        timeout = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lostControl)//если управление не потеряно
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (isDrag == false)//если не тащим
            {
                if (Physics.Raycast(ray, out hitInfo))//стреляем лучом
                {
                    Debug.DrawLine(ray.origin, hitInfo.point);
                    go = hitInfo.collider.gameObject;//выбираем объект, в который попал луч
                    screenSpace = Camera.main.WorldToScreenPoint(go.transform.position);//проецируем на экран
                }
            }
            if (Input.GetMouseButton(0))//если нажали кнопку мыши 
            {
                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);//позиция мыши
                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace);//проецируем в мир
                if (go != null)//если объект выбран
                {
                    go.transform.position = new Vector3(currentPosition.x, currentPosition.y);//изменять его позицию в соотвествии проецируемой позиции мыши
                }
                isDrag = true;//тащим
            }
            else//если кнопка мыши не нажата
            {
                isDrag = false;//не тащим
                go = null;//объект не выбран
            }
        }
        else
        {//если потеряли контроль
            go = null;//теряем объект
            timeout -= Time.deltaTime;//ждём время
            if (timeout <= 0)
            {//когда время истекает
                lostControl = false;//можем снова управлять
                timeout = cooldown;//обновляем таймер
            }
        }
    }

    public void Reject()//теряем управление над кубом
    {
        lostControl = true;
    }
}
