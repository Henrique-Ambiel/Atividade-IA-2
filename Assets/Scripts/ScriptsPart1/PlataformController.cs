using UnityEngine;

public class PlataformContror : MonoBehaviour
{
    private float velocity = 2.0f;

    void Update()
    {
        transform.Rotate(Time.deltaTime * velocity * 1.0f, 0.0f, 0.0f, Space.Self);

        if((transform.rotation.eulerAngles.x <= 45.0f) || (transform.rotation.eulerAngles.x >= 315.0f))
        {
            velocity = 1 * velocity;
        }
        else
        {
            velocity = -1 * velocity;
        }
           
    }
}
