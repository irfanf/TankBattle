using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _rotationSpeed = 100.0f;
    //[SerializeField] private GameObject _bulletGO;
    [SerializeField] private GameObject _shotSpawn;
    //[SerializeField] private float _bulletSpeed;

    //[SerializeField]
    //private Bullet _bullet;

    public GameObject a;

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //_bullet.setShotSpawn(_shotSpawn);
            //_bullet.Shoot();
            GameObject bullet = (GameObject)Instantiate(a, _shotSpawn.transform.position, _shotSpawn.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50.0f;
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10000);
        }

        float translation = Input.GetAxis("Vertical") * _speed;
        float rotation = Input.GetAxis("Horizontal") * _rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);


    }
}
