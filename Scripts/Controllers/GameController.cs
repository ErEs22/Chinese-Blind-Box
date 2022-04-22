using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 游戏控制器
/// </summary>
public class GameController : Singleton<GameController>
{
    [SerializeField] WordDB_SO wordDB;
    [HideInInspector] public List<GameObject> selectedCards;//配对卡片的集合
    [HideInInspector] public bool isListFull;
    protected override void Awake()
    {
        base.Awake();
        wordDB.AddData();
        selectedCards = new List<GameObject>();
    }
    public void CompareCards()//配对选中的两张卡片
    {
        print(selectedCards.Count);
        if (wordDB.wordDic["新"].Contains(selectedCards[0].GetComponent<BlockEvent>().value) && wordDB.wordDic["新"].Contains(selectedCards[1].GetComponent<BlockEvent>().value))
        {
            selectedCards[0].GetComponent<BlockEvent>().isCompared = true;
            selectedCards[1].GetComponent<BlockEvent>().isCompared = true;
            selectedCards[0].GetComponent<BlockEvent>().valueText.text = "";
            selectedCards[1].GetComponent<BlockEvent>().valueText.text = "";
            selectedCards[0].GetComponent<Image>().color = new Color(1, 1, 1, 0);
            selectedCards[0].transform.Find("Frame").GetComponent<Image>().color = new Color(1, 1, 1, 0);
            selectedCards[1].GetComponent<Image>().color = new Color(1, 1, 1, 0);
            selectedCards[1].transform.Find("Frame").GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
        else//配对失败则将两张卡片设为未选中的状态
        {
            selectedCards[0].GetComponent<Image>().color = new Color(1, 1, 1, 0);
            selectedCards[1].GetComponent<Image>().color = new Color(1, 1, 1, 0);
            selectedCards[0].GetComponent<BlockEvent>().isSelected = false;
            selectedCards[1].GetComponent<BlockEvent>().isSelected = false;
        }
        //将卡片设置为透明并且状态设置为已配对
        selectedCards.Clear();
        isListFull = false;
    }
}
