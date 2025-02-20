using UnityEngine;

public class NpcController : MonoBehaviour
{
    private Animator animationOfController;

    public GameObject player;
    public GameObject npc;

    private float distanceFromTarget;
    private float maximumDistanceAllowed = 4.0f;
    private float persecutionVelocity = 4.0f;

    private RaycastHit hitInfo;
    private bool hitRay = false;

    void Start()
    {
        animationOfController = npc.GetComponent<Animator>();
        animationOfController.SetBool("jogadorPerto", true); 
    }

    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));

        hitRay = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo);
        Debug.DrawRay(transform.position, dir: transform.TransformDirection(Vector3.forward) * 100.0f, color: Color.yellow);
        distanceFromTarget = hitInfo.distance;

        if(distanceFromTarget >= maximumDistanceAllowed)
        {
            animationOfController.SetBool("jogadorPerto", false);
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z),
                persecutionVelocity * Time.deltaTime
                );
        }

        if(distanceFromTarget < maximumDistanceAllowed)
        {
            persecutionVelocity = 0.0f;
            animationOfController.SetBool("jogadorPerto", true);
        }

        if(hitInfo.collider.gameObject.name != "PlayerBack")
        {
            animationOfController.SetBool("jogadorPerto", false);

            Vector3 npcNoseDirection = transform.TransformDirection(Vector3.forward);
            Vector3 playerNoseDirection = player.transform.TransformDirection(Vector3.forward);

            if(Vector3.Cross(npcNoseDirection, playerNoseDirection).y < 0.0f)
            {
                transform.RotateAround(player.transform.position, Vector3.up, -100.0f * Time.deltaTime);
            }
            else
            {
                transform.RotateAround(player.transform.position, Vector3.up, 100.0f * Time.deltaTime);
            }
        }
    }
}
