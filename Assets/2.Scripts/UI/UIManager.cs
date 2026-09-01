using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
}
