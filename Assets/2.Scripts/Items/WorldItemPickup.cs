using UnityEngine;

public class WorldItemPickup : MonoBehaviour
{
    [SerializeField] ItemData itemData;
    [SerializeField, Min(1)] int count = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(itemData.displayName);
            Debug.Log(count);
        }
       
    }
}
