using UnityEngine;
using TMPro;

public class HUD_Controller : MonoBehaviour
{
    [Header("HUD Text Elements")]
    [SerializeField] TextMeshProUGUI[] hudTexts;

    private bool isHudVisible = true;

    public void ToggleHUD()
    {
        isHudVisible = !isHudVisible;
        SetHUD(isHudVisible);
    }

    private void SetHUD(bool value)
    {
        foreach (var text in hudTexts)
        {
            if (text != null)
                text.gameObject.SetActive(value);
        }
    }
}
