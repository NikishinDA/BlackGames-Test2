using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrillerScript : MonoBehaviour
{
    private GameObject go;
    private Vector3 screenSpace;
    private bool isDrage = false;
    private bool lostControl = false;
    private float timeout;
    public float cooldown = 2.0f;


    // Use this for initialization
    void Start()
    {
        timeout = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lostControl)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (isDrage == false)
            {
                if (Physics.Raycast(ray, out hitInfo))
                {
                    Debug.DrawLine(ray.origin, hitInfo.point);
                    go = hitInfo.collider.gameObject;
                    screenSpace = Camera.main.WorldToScreenPoint(go.transform.position);
                }
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace);
                if (go != null)
                {
                    go.transform.position = new Vector3(currentPosition.x, currentPosition.y);
                }
                isDrage = true;
            }
            else
            {
                isDrage = false;
                go = null;
            }
        }
        else
        {
            go = null;
            timeout -= Time.deltaTime;
            if (timeout <= 0)
            {
                lostControl = false;
                timeout = cooldown;
            }
        }
    }

    public void Reject()
    {
        lostControl = true;
    }
}
