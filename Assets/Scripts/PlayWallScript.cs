using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayWallScript : MonoBehaviour
{
    public string color;
    public float forceMultipier = 5;
    public Text scoreText;
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag(color))
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = score.ToString();
        }
        else
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(1,0) * forceMultipier;
            FindObjectOfType<ContrillerScript>().Reject();
        }
    }
}
