using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 诗词
/// </summary>
[System.Serializable]
public class Poetry
{
    public enum AnswerType
    {
        above,
        next
    }
    public AnswerType answerType;
    public string key;
    public string value;
}
