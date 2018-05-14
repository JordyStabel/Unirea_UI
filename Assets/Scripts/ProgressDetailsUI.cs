using UnityEngine;
using UnityEngine.UI;

public class ProgressDetailsUI : MonoBehaviour {

    public GameObject UI;

    public Text duration;
    public Text objectName;
    public Button cancel;

    private bool isActive = false;

    public void SetTarget() // needs input
    {
        //          target = _target;
        //        transform.position = target.GetBuildPosition();
        //        sellValue.text = "$" + target.turretBlueprint.GetSellValue();

        //        if (!target.isUpgraded)
        //        {
        //            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
        //            upgradeButton.interactable = true;
        //        }
        //        else
        //        {
        //            upgradeButton.interactable = false;
        //            upgradeCost.text = "MAX LV.";
        //        }

        //        UI.SetActive(true);

        UI.SetActive(true);
    }

    public void ToggleUI()
    {
        // Flip the isActive state of the UI object
        UI.SetActive(!UI.activeSelf);
    }
}