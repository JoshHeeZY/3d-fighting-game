using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Offsets")]
    public Vector3 offset = new Vector3(0f, 5f, -8f);

    [Header("Follow Settings")]
    public float followSpeed = 10f;
    public float lookSpeed = 10f;

    private void LateUpdate()
    {
        if (!target) return;

        // Desired position
        Vector3 desiredPos = target.position + target.transform.TransformDirection(offset);

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);

        // Smooth rotation
        Quaternion desiredRot = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRot, lookSpeed * Time.deltaTime);
    }
}
