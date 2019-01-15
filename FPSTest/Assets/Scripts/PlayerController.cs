using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 velocity;
    public GameObject doorPrefab;
    private float pitch = 0f;
    private float minPitch = -80f;
    private float maxPitch = 80f;

    // Start is called before the first frame update
    void Start()
    {
        velocity.Set(0, 0, 0);
        //Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            velocity += transform.forward * 0.03f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += transform.forward * -0.03f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += transform.right * -0.03f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += transform.right * 0.03f;
        }
        //velocity += transform.up * -0.01f;
        transform.position += velocity;
        velocity = Vector3.Lerp(velocity, Vector3.zero, 0.2f);

        transform.Rotate(0, Input.GetAxis("Mouse X") * 5.0f, 0);

        pitch -= Input.GetAxis("Mouse Y") * 5.0f;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        Camera.main.transform.eulerAngles = new Vector3(pitch, transform.eulerAngles.y, 0);
        Ray ray = new Ray(transform.position, Camera.main.transform.eulerAngles);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider != null && hit.transform.gameObject == doorPrefab)
            {
                hit.transform.gameObject.GetComponent<Animator>().SetBool("open", true);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        velocity = Vector3.zero;
    }
}
