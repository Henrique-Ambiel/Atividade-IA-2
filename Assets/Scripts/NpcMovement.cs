using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public int moveSpeed = 2;
    public Vector3 npcRotation = new Vector3(0, 0, 0);
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + transform.forward, transform.TransformDirection(Vector3.down), out hit))
        {
            transform.Translate(transform.TransformDirection(transform.forward) * moveSpeed * Time.deltaTime);
        }
        else
        {
            npcRotation = new Vector3(0, 180, 0);
            transform.Rotate(npcRotation);
        }

    }
}
