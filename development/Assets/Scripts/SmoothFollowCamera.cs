using UnityEngine;

/// <summary>대상 뒤쪽 위에서 부드럽게 따라가며 바라보는 카메라.</summary>
public class SmoothFollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 3.2f, -4.5f);
    public float followSharpness = 3f;
    public float lookHeight = 0.6f;

    void LateUpdate()
    {
        if (target == null) return;
        Vector3 desired = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desired, 1f - Mathf.Exp(-followSharpness * Time.deltaTime));
        Vector3 look = target.position + Vector3.up * lookHeight - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look), 1f - Mathf.Exp(-followSharpness * Time.deltaTime));
    }
}
