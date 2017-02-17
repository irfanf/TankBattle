using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIShoot : MonoBehaviour {

    [SerializeField] private float speedRot = 0.5f;
    [SerializeField] private float aspd = 0.5f;
    [SerializeField] private float minDist = 5.0f;
    [SerializeField] private GameObject _shotSpawn;
    [SerializeField] private GameObject bulletGO;

    [SerializeField] private GameObject[] objects;
    private int objectNum;
    private bool LockOn;

    private float timer;

    private GameObject target;

	// Use this for initialization
	void Start () {
        target = null;
        timer = 0;
     
	}
	
	// Update is called once per frame
	void Update () {
        objectNum = Random.Range(0, objects.Length);

        float dist = Vector3.Distance(gameObject.transform.position, objects[objectNum].transform.position);
        //Debug.Log(dist);

        if (dist <= minDist)
        {
            if (target == null)
            {
                target = objects[objectNum];
                //objectsInRange.Add(objects[objectNum]);

            }
            else
            {
                timer += Time.deltaTime;

                Debug.Log(this.gameObject.name.ToString() + "target is = " + target.name.ToString());
                float targetDist = Vector3.Distance(gameObject.transform.position, target.transform.position);
                Vector3 relativePos = target.transform.position - transform.position;
                Quaternion rot = Quaternion.LookRotation(relativePos);
                transform.rotation = rot;

                if(timer > aspd)
                {
                    GameObject bullet = (GameObject)Instantiate(bulletGO, _shotSpawn.transform.position, _shotSpawn.transform.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50.0f;
                    timer = 0;
                }


                if(targetDist > minDist)
                {
                    target = null;
                }
            }
        }
        else
        {
            objectNum = Random.Range(0, objects.Length);
        }
    }
}
