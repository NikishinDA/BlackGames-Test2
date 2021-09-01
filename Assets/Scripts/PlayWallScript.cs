using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayWallScript : MonoBehaviour
{
    public string color;//���� �����
    public float forceMultipier = 5;//��������� � ����������� ���� �������
    public Text scoreText;//����� �����
    public GameObject controllerObject;//������ � �����������
    public GameObject gameManagerObject;//������ ���������

    private int score = 0;//����
    private ContrillerScript contrillerScript;//������ ����������
    private GameManagerScript gmScript;//������ ���������
    private void Start()
    {
        contrillerScript = controllerObject.GetComponent<ContrillerScript>();
        gmScript = gameManagerObject.GetComponent<GameManagerScript>();

    }

    private void OnTriggerEnter(Collider other)//��� ��������� � ������ �������
    {
        if (other.CompareTag(color))//���� �� ���� �� �����
        {
            Destroy(other.gameObject);//����������
            score++;//��������� ����
            scoreText.text = score.ToString();//������� �� �����
            gmScript.cubeDestoyed();//�������� ���������
        }
        else//���� ������� �����
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(1,0) * forceMultipier;//�������� ���
            contrillerScript.Reject();//�������� ����������
        }
    }
}
