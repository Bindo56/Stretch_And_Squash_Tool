using UnityEngine;

public class CubeClickManager : MonoBehaviour
{
    public Camera cam;
    [SerializeField] CubeClickTarget defaultHeadDir;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                CubeClickTarget cube = hit.transform.GetComponent<CubeClickTarget>();

                if (cube != null)
                {
                    cube.headMover.MoveToTarget(hit.transform);
                }
            }
        }
    }

    public void HeadDeafult()
    {
        defaultHeadDir.headMover.MoveToTarget(defaultHeadDir.transform);
    }
}
