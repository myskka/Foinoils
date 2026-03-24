using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            TrashCounter counter = FindFirstObjectByType<TrashCounter>();
            if (counter != null)
            {
                counter.ItemCollected();
            }
            
            Destroy(other.gameObject);
        }
    }
}