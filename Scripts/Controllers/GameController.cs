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
    [SerializeField] Text compareWord;//配对的文字组件
    [HideInInspector] public List<GameObject> selectedCards;//配对卡片的集合
    [HideInInspector] public bool isListFull;
    List<string> levelOneList;
    protected override void Awake()
    {
        base.Awake();
        wordDB.AddData();
        selectedCards = new List<GameObject>();
        levelOneList = new List<string>();
    }
    private void Start()
    {
        InitilizeLevelList();
        SetRandomText();
    }
    void InitilizeLevelList()//初始化关卡文字库
    {
        foreach (var item in wordDB.wordDic)
        {
            levelOneList.Add(item.Key);
        }
    }
    void SetRandomText() => compareWord.text = levelOneList[Tool.GetRandomNumber(0, levelOneList.Count)];//设置随机的一个汉字
    public void CompareCards()//配对选中的两张卡片
    {
        // print(selectedCards.Count);
        if (!isListFull)
        {
            //TODO:提示玩家需要选择两个卡片进行配对
            print("请选择两张卡片进行配对");
            return;
        }
        if (wordDB.wordDic[compareWord.text].Contains(selectedCards[0].GetComponent<BlockEvent>().value) &&
        wordDB.wordDic[compareWord.text].Contains(selectedCards[1].GetComponent<BlockEvent>().value))//配对成功，将两张卡片隐藏并更新将要配对的文字
        {
            selectedCards[0].GetComponent<BlockEvent>().isCompared = true;
            selectedCards[1].GetComponent<BlockEvent>().isCompared = true;
            selectedCards[0].GetComponent<BlockEvent>().valueText.text = "";
            selectedCards[1].GetComponent<BlockEvent>().valueText.text = "";
            selectedCards[0].GetComponent<Image>().color = new Color(1, 1, 1, 0);
            selectedCards[0].transform.Find("Frame").GetComponent<Image>().color = new Color(1, 1, 1, 0);
            selectedCards[1].GetComponent<Image>().color = new Color(1, 1, 1, 0);
            selectedCards[1].transform.Find("Frame").GetComponent<Image>().color = new Color(1, 1, 1, 0);
            levelOneList.Remove(compareWord.text);
            if (levelOneList != null)
            {
                SetRandomText();
            }
            else
            {
                //TODO成功消除所有卡片，提示玩家已通关

                print("成功消除所有卡片，你可以进入下一关了");
            }
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
