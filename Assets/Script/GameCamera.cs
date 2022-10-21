using UnityEngine;
public class GameCamera : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public float smoothness = 5f;

    private Vector3 targetPosition;

    void Update()
    {
        if(target != null)
        {
            targetPosition = target.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothness);
        }
    }
}
