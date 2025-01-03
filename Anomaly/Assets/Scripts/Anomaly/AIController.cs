using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [HideInInspector] public GameObject player;
    [HideInInspector] public NavMeshAgent agent;
    public float pathUpdateDelay = 5f;
    public float lookSpeed = 0.2f;
    public float runDistance = 350.0f;
    private Animator anomalyAnim;
    private bool gameOver;
    private float pathUpdateDeadline;

    // Start is called before the first frame update
    void Start()
    {
        anomalyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool inRange = (Vector3.Distance(transform.position, player.transform.position) <= runDistance);

        if (inRange)
        {
            anomalyAnim.SetFloat("Speed", 1);
            agent.velocity = agent.desiredVelocity * 2;
        } else
        {
            anomalyAnim.SetFloat("Speed", 0);
            agent.velocity = agent.desiredVelocity;
        }
        UpdatePath();
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        if (!gameOver)
        {
            Vector3 lookPos = transform.position - player.transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, lookSpeed);
        }
    }

    private void UpdatePath()
    {
        if (Time.time >= pathUpdateDeadline && !gameOver)
        {
            Debug.Log("Path Updated");
            pathUpdateDeadline = Time.time + pathUpdateDelay;
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out _))
        {
            Debug.Log("Game Over");
            anomalyAnim.SetBool("GameOver", true);
            agent.isStopped = true;
            gameOver = true;
        }
    }
}
