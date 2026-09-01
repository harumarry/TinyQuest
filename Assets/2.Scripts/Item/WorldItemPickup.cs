using UnityEngine;

public class WorldItemPickup : MonoBehaviour
{
    [SerializeField] ItemData itemData;
    [SerializeField, Min(1)] int count = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory inventory = collision.GetComponent<Inventory>();

            int remainingCount = inventory.AddItem(itemData, count);

            if (remainingCount > 0)
            {
                count = remainingCount;
            }
            else if (remainingCount == 0)
            {               
                Destroy(gameObject);
            }
        }
       
    }
}
