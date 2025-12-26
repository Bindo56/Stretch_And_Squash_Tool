using UnityEngine;

public class RuntimeIKDragHandle : MonoBehaviour
{
    Camera cam;
    bool dragging = false;
    float dragDistance;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    dragging = true;
                    dragDistance = hit.distance; // keep distance from camera
                }
            }
        }


        if (Input.GetMouseButtonUp(0))
            dragging = false;

        if (dragging)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 newPos = ray.GetPoint(dragDistance);

            transform.position = newPos;
        }
    }
}
