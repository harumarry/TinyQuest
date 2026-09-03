using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject itemDetailPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            itemDetailPanel.SetActive(false);
        }
    }
}
