using UnityEngine;

public class TrashItem : MonoBehaviour
{
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // LMB
        {
            CollectTrash();
        }
    }

    void CollectTrash()
    {
        if (TrashCounter.Instance != null)
        {
            TrashCounter.Instance.ItemCollected();
        }

        Destroy(gameObject);
    }
}