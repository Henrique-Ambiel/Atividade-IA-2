using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float frontVelocity = 8.0f;
    private float backVelocity = 10.0f;

    void Update()
    {
        float horizontalKeys = Input.GetAxis("Horizontal");
        float verticalKeys = Input.GetAxis("Vertical");

        if(verticalKeys < 0.0f)
        {
            verticalKeys = 0.0f;
        }

        transform.Rotate(0.0f, horizontalKeys * backVelocity * Time.deltaTime, 0.0f, Space.Self);
        transform.Translate(0.0f, 0.0f, verticalKeys * frontVelocity * Time.deltaTime, Space.Self);
    }
}
