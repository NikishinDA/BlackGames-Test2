using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private int cubeNumber = 5;//����� ����� �� ����

    public GameObject restartUI;//UI ��� �������� (�������������)

    void Update()
    {
        if (cubeNumber == 0)//���� ������ ����� ���
        {
            restartUI.SetActive(true);//�������� ������� ������
        }
    }

    public void cubeDestoyed()//����� ��� ������������
    {
        cubeNumber--;//��������� ����� �����
    }
}
