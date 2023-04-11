using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageUIManager : MonoBehaviour
{
    public TextMeshProUGUI stageText; //このスクリプトとUIを紐付け
    public GameObject nextButton;
    public GameObject toTownButton;
    public GameObject stageClearImage;

    private void Start()
    {
        stageClearImage.SetActive(false);
    }


    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("Stage:{0}", currentStage+1);
    }

    public void HideButtons()
    {
        nextButton.SetActive(false);
        toTownButton.SetActive(false);
    }
    public void ShowButtons()
    {
        nextButton.SetActive(true);
        toTownButton.SetActive(true);
    }

    public void ShowClearText()
    {
        stageClearImage.SetActive(true);
        nextButton.SetActive(false);
        toTownButton.SetActive(true);
    }
}
