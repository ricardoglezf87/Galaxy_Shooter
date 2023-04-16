using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    
    [SerializeField]
    private GameObject _laserPrefab;
    
    [SerializeField]
    private float _fireRate = 0.25f;    
    
    private float _nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicializando...." + name);
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        shoot();
    }

    private void shoot()
    {
       if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) && Time.time > _nextFire)
       {
            _nextFire = Time.time + _fireRate;
            Instantiate(_laserPrefab,transform.position + new Vector3(0,0.88f,0),Quaternion.identity);
       }     
    }

    private void move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * _speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * _speed);

        //Limits

        if(transform.position.y > 0)
            transform.position = new Vector3(transform.position.x,0,transform.position.z);
        else if(transform.position.y < -4.2f)
            transform.position = new Vector3(transform.position.x,-4.2f,transform.position.z);
        
        if(transform.position.x > 9f)
            transform.position = new Vector3(-9f,transform.position.y,transform.position.z);
        else if(transform.position.x < -9f)
            transform.position = new Vector3(9f,transform.position.y,transform.position.z);
    }
}
