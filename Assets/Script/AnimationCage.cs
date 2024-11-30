using UnityEngine;

public class AnimationCage : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedRotate = 5f;

    public Waypoint point;    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * speedRotate * Time.fixedDeltaTime, Space.Self);

        Vector3 dir = point.transform.position - transform.position;
        transform.position += dir.normalized * speed * Time.fixedDeltaTime;
        if (dir.magnitude < 0.8f)
        {
            int i = Random.Range(0, point.nextPoint.Length);
            point = point.nextPoint[i];

        }
    }
}
