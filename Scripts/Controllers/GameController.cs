using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 游戏控制器
/// </summary>
public class GameController : Singleton<GameController>
{
    [HideInInspector] public List<GameObject> selectedCards;//配对卡片的集合
    [HideInInspector] public bool isListFull;
    protected override void Awake()
    {
        base.Awake();
        selectedCards = new List<GameObject>();
    }
    public void CompareCards()//配对选中的两张卡片
    {
        print(selectedCards.Count);
        foreach (var card in selectedCards)
        {
            //TODO 添加配对条件
            //将卡片设置为透明并且状态设置为已配对
            card.GetComponent<BlockEvent>().isCompared = true;
            card.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            card.transform.Find("Frame").GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
        selectedCards.Clear();
        isListFull = false;
    }
}
