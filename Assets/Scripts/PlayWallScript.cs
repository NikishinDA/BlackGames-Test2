using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWallScript : MonoBehaviour
{
    public string color;
    public float forceMultipier = 5;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag(color))
        {
            Destroy(other.gameObject);
            //add score
        }
        else
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(1,0) * forceMultipier;
            FindObjectOfType<ContrillerScript>().Reject();
        }
    }
}
