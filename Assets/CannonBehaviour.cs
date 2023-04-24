using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour
{
    Collider AttackRadius;
    [SerializeField] GameObject CannonBall;
    GameObject target;
    [SerializeField] GameObject ProjectileSpawn;
    List<GameObject> targets = new List<GameObject>();
    float Timestamp;
    [SerializeField]float Firerate = 0.6f;
    [SerializeField] float ProjectileSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.LookAt(target.transform.position, Vector3.up);
            if (Timestamp + Firerate < Time.time)
            {
                Timestamp = Time.time;
                Vector3 shootDirection = target.transform.position - gameObject.transform.position;
                shootDirection.Normalize();
                shootDirection.y = 0;
                GameObject ball = Instantiate(CannonBall, ProjectileSpawn.transform.position, transform.rotation);
                ball.GetComponent<Rigidbody>().velocity = shootDirection * ProjectileSpeed;
            }
        }
        else if (targets.Count > 0)
        {
            target = GetTarget();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!targets.Contains(collision.gameObject))
            {
                targets.Add(collision.gameObject);
                if (!target)
                {
                    target = GetTarget();
                }
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (targets.Contains(collision.gameObject))
        {
            targets.Remove(collision.gameObject);
            if (target.gameObject == collision.gameObject)
            {
                target = null;
            }

        }
    }
    GameObject GetTarget()
    {
        GameObject nextTarget = null;
        if (targets.Count > 0)
        {
            nextTarget = targets[0];
        }
        return nextTarget;
    }
}
