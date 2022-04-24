using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 诗词接龙游戏控制器
/// </summary>
public class PSController : Singleton<PSController>
{
    [SerializeField] PoetryDB_SO poetryDB;
    [SerializeField] Text poetText;//诗人提出的诗词
    [SerializeField] Text answerText;//玩家回答的文本
    [SerializeField] Text answerType;//答案的类型，上一句还是下一句
    int currentIndex = 0;
    protected override void Awake()
    {
        base.Awake();
        poetryDB.AddData();
    }
    private void Start()
    {
        ChangeAnswerType();
        poetText.text = poetryDB.poetry[currentIndex].key;
    }
    void ChangeAnswerType()//更新问题的类型的文本，根据当前的诗词的答案类型进行改变
    {
        if (poetryDB.poetry[currentIndex].answerType == Poetry.AnswerType.above)//如果是above则这句诗词的答案是写出上一句
        {
            answerType.text = "请说出上一句";
        }
        else//如果是其他比如next则这句诗词的答案是写出下一句
        {
            answerType.text = "请说出下一句";
        }
    }
    public void ComparePoetry()//根据玩家输入的答案进行配对
    {
        if (poetryDB.poetry[currentIndex].answerType == Poetry.AnswerType.above)//答案类型为上一句，将诗人的诗词放在后面，玩家的答案放在前面
        {
            if (poetryDB.poetryDic[poetText.text].value == (answerText.text + "，" + poetText.text))
            {
                NextQuestion();//进入下一题
                answerText.GetComponentInParent<InputField>().text = "";//清空答题文本内容
                print("恭喜你！ 答对了");
            }
            else
            {
                //TODO提示玩家答案错误，需要更改答案
                print("答案错误！");
            }
        }
        if (poetryDB.poetry[currentIndex].answerType == Poetry.AnswerType.next)//答案类型为下一句，将诗人的诗词放在后面，玩家的答案放在前面
        {
            if (poetryDB.poetryDic[poetText.text].value == (poetText.text + "，" + answerText.text))
            {
                NextQuestion();//进入下一题
                answerText.GetComponentInParent<InputField>().text = "";//清空答题文本内容
                print("恭喜你！ 答对了");
            }
            else
            {
                //TODO提示玩家答案错误，需要更改答案
                print("答案错误！");
            }
        }
    }
    void NextQuestion()//进入下一题
    {
        if (currentIndex == 9)
        {
            //TODO提示玩家成功通过次关，可以进入下一关
            return;
        }
        currentIndex++;//将题目序号加一
        poetText.text = poetryDB.poetry[currentIndex].key;
    }
}
