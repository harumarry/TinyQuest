using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject itemDetailPanel;
    [SerializeField] GameObject equipmentPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // 인벤토리
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            itemDetailPanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E)) // 장비창
        {
            equipmentPanel.SetActive(!equipmentPanel.activeSelf);
        }
    }
}
