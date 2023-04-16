using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    public GameObject laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicializando...." + name);
        transform.position = new Vector3(0,0,0);
    }



    // Update is called once per frame
    void Update()
    {
        movement();
        shooting();
    }

    private void shooting()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
            Instantiate(laserPrefab,transform.position + new Vector3(0,0.88f,0),Quaternion.identity);
       }     
    }


    private void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);

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
