using UnityEngine;

public class LookAtCam_BillBoard : MonoBehaviour
{
    public Camera targetCamera;

    [Header("Settings")]
    public bool lockXAxis = false;
    public bool lockYAxis = false;
    public bool lockZAxis = false;

    void LateUpdate()
    {
        if (targetCamera == null) targetCamera = Camera.main;
        if (targetCamera == null) return;

        Quaternion targetRotation = targetCamera.transform.rotation;

        if (lockXAxis || lockYAxis || lockZAxis)
        {
            Vector3 euler = targetRotation.eulerAngles;
            if (lockXAxis) euler.x = transform.eulerAngles.x; // X
            if (lockYAxis) euler.y = transform.eulerAngles.y; // Y
            if (lockZAxis) euler.z = transform.eulerAngles.z; // Z
            targetRotation = Quaternion.Euler(euler);
        }

        transform.rotation = targetRotation;
    }
}

