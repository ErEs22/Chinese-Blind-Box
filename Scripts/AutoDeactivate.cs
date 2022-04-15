using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 自动销毁或者禁用
/// </summary>
public class AutoDeactivate : MonoBehaviour
{
    [SerializeField] float lifeTime = 3f;
    [SerializeField] bool destroyGameObject;
    WaitForSeconds waitLifeTime;
    private void Awake()
    {
        waitLifeTime = new WaitForSeconds(lifeTime);
    }
    private void OnEnable()
    {
        StartCoroutine(nameof(DeactivateCoroutine));
    }
    IEnumerator DeactivateCoroutine()
    {
        yield return waitLifeTime;//等待销毁或禁用时间
        if (destroyGameObject)
        {
            Destroy(gameObject);//销毁对象
        }
        else
        {
            if (gameObject.activeSelf == true)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
