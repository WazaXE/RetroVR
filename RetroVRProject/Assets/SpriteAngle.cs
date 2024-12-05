using UnityEngine;

public class SpriteAngle : MonoBehaviour
{
    public Transform target; 
    public float rotationSpeed = 1.0f; 
    public bool limitX = false;
    public bool limitY = false;
    public bool limitZ = false;

    [Range(-180f, 180f)] public float minX = -45f;
    [Range(-180f, 180f)] public float maxX = 45f;

    [Range(-180f, 180f)] public float minY = -45f;
    [Range(-180f, 180f)] public float maxY = 45f;

    [Range(-180f, 180f)] public float minZ = -45f;
    [Range(-180f, 180f)] public float maxZ = 45f;

    void Update()
    {
        if (target == null) return;
        Vector3 directionToTarget = target.position - transform.position;
        directionToTarget.y = 0; 

        if (directionToTarget == Vector3.zero) return;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        Vector3 targetEulerAngles = targetRotation.eulerAngles;

        if (limitX)
        {
            targetEulerAngles.x = Mathf.Clamp(NormalizeAngle(targetEulerAngles.x), minX, maxX);
        }
        if (limitY)
        {
            targetEulerAngles.y = Mathf.Clamp(NormalizeAngle(targetEulerAngles.y), minY, maxY);
        }
        if (limitZ)
        {
            targetEulerAngles.z = Mathf.Clamp(NormalizeAngle(targetEulerAngles.z), minZ, maxZ);
        }

        targetRotation = Quaternion.Euler(targetEulerAngles);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private float NormalizeAngle(float angle)
    {
        while (angle > 180) angle -= 360;
        while (angle < -180) angle += 360;
        return angle;
    }
}
