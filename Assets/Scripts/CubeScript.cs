using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private GameObject go;
    private Vector3 screenSpace;
    private bool isDrage = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
                go.transform.position = currentPosition;
            }
            isDrage = true;
        }
        else
        {
            isDrage = false;
        }
    }

}
