using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public float speed;
    public Vector3 dir;
    public Vector3 rotate;

    private void Start()
    {
        transform.Rotate(rotate);
    }

    void FixedUpdate()
    {
        transform.Translate(speed * dir * Time.deltaTime, Space.World);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Bot") && other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
