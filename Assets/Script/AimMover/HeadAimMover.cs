using UnityEngine;

public class HeadAimMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float stopDistance = 0.05f;

    Transform target;

    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) <= stopDistance)
            target = null;
    }

    public void MoveToTarget(Transform cube)
    {
        target = cube;
    }
}
