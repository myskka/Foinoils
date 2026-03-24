using UnityEngine;
using TMPro;

public class TrashCounter : MonoBehaviour
{
    public static TrashCounter Instance;

    [SerializeField] private string itemTag = "Item";
    [SerializeField] private TextMeshProUGUI trashCountText;

    private int totalItems;
    private int remainingItems;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CountItems();
    }

    public void CountItems()
    {
        GameObject[] allItems = GameObject.FindGameObjectsWithTag(itemTag);

        totalItems = allItems.Length;
        remainingItems = totalItems;

        UpdateUI();

        Debug.Log("Total trash: " + totalItems);
    }

    public void ItemCollected()
    {
        if (remainingItems > 0)
        {
            remainingItems--;
            UpdateUI();
        }

        if (remainingItems <= 0)
        {
            remainingItems = 0;
            Debug.Log("All items collected!");
        }
    }

    private void UpdateUI()
    {
        if (trashCountText != null)
        {
            trashCountText.text = "TRASH LEFT: " + remainingItems;
        }
    }

    public int GetRemainingItems()
    {
        return remainingItems;
    }
}