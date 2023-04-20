using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class QuestManager : MonoBehaviour
{

    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;
    public GameObject questBG;

    //　敵に遭遇するテーブル：０で遭遇する
    int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    int currentStage = 0; //現在のステージ進行度
    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[] { "arrived at the forest." });
    }

    IEnumerator Searching()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "explore..." });
        //背景を大きくする
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f)
            .OnComplete(() => questBG.transform.localScale =new Vector3(1, 1, 1));
        //背景をフェードアウトする
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 2f)
         .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0f));
        //２秒間処理を待機する
        yield return new WaitForSeconds(2f);

      
        currentStage++;
        stageUI.UpdateUI(currentStage);

        if (encountTable.Length <= currentStage)
        {
            Debug.Log("クエストクリア");
            QuestClear();

        }
        else if(encountTable[currentStage] == 0)
        {
            EncountEnemy();
        }
        else
        {
            stageUI.ShowButtons();
        }

    }

    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.HideButtons();
        StartCoroutine(Searching());
    }

    public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    void EncountEnemy()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "encounter an enemy !" });
        stageUI.HideButtons();
        GameObject enemyObj = Instantiate(enemyPrefab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
    }

    public void EndBattle()
    {
        stageUI.ShowButtons();
    }

    void QuestClear()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "You got treasure box ! \n Let's back town." });
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);
        //クエストクリアを表示
        //街に戻るボタンのみ表示
        stageUI.ShowClearText();
        //sceneTransitionManager.LoadTo("Town");
    }

    public void PlayerDeath()
    {
        sceneTransitionManager.LoadTo("Town");
    }

}
