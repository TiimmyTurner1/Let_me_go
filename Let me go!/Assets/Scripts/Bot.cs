using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 dir;
    [SerializeField] private Vector3 rotate;

    private void Start()
    {
        transform.Rotate(rotate);
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * dir * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
            Destroy(gameObject);
    }
}
