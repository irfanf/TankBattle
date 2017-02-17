using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private float _bulletSpeed = 10000.0f;
    public GameObject _shotSpawn;

    //public void setShotSpawn(GameObject shotSpawn)
    //{
    //    _shotSpawn = shotSpawn;
    //}
    //
    //void Start()
    //{
    //    _shotSpawn = new GameObject();   
    //}

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);    
    }

    //void Update()
    //{
    //    Shoot();
    //}
    //
    //public void Shoot()
    //{
    //    GameObject bullet = (GameObject)Instantiate(this.gameObject, _shotSpawn.transform.position, _shotSpawn.transform.rotation);
    //    bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletSpeed);
    //}
}
