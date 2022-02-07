using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private GameObject[] firstGroup;
    [SerializeField] private GameObject[] secondGroup;
    [SerializeField] private Activator button;
    [SerializeField] private Material normal;
    [SerializeField] private Material transparent;
    [SerializeField] private Material normalbtn;
    [SerializeField] private Material activatedbtn;

    public bool canPush;

    private void OnTriggerEnter(Collider other)
    {
        if (canPush)
        {
            if (other.CompareTag("Button") || other.CompareTag("Player"))
            {
                foreach (GameObject first in firstGroup)
                {
                    first.GetComponent<Renderer>().material = normal;
                    first.GetComponent<Collider>().isTrigger = false;
                }

                foreach (GameObject second in secondGroup)
                {
                    second.GetComponent<Renderer>().material = transparent;
                    second.GetComponent<Collider>().isTrigger = true;
                }

                GetComponent<Renderer>().material = activatedbtn;
                button.GetComponent<Renderer>().material = normalbtn;
                button.canPush = true;
            }
        }
    }
}
