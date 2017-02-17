using UnityEngine;
using System.Collections;

public class TankBehaviour : MonoBehaviour {

    [SerializeField] private float hp = 10;


    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private int num;
    [SerializeField] private float minDist;
    [SerializeField] private float speed;

    private NavMeshAgent navMeshAgent;



    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            hp--;
            Debug.Log(hp);
        }

    }
    void Start()
    {
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            if(dist > minDist)
            {
                Move();
            }
            else
            {
                //num++;
                num = Random.Range(0, waypoints.Length);
            }
        }
    }
    void Move()
    {

        //gameObject.transform.LookAt(waypoints[num].transform.position);
        //gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        navMeshAgent.SetDestination(waypoints[num].transform.position);
    }


}

