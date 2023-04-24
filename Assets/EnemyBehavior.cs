using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] GameObject tower;
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = tower.transform.position;
    }
    private void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
