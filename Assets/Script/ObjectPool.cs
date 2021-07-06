using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int initailSize = 10;//物件池內的物件數N

    private Queue<GameObject> objPool = new Queue<GameObject>();//佇列

    void Awake()//場景生成時
    {
        for (int cnt = 0; cnt < initailSize; cnt++)
        {
            GameObject go = Instantiate(prefab) as GameObject;//生成0~N個物件
            objPool.Enqueue(go);//將生成的物件放入佇列中
            go.SetActive(false);//把物件設定為不啟用
        }
    }

    public void ReUse(Vector3 position, Quaternion rotation)//取出物件，參數指定位置和角度
    {
        if (objPool.Count > 0)//物件池內還有物件時
        {
            GameObject reuse = objPool.Dequeue();//將最先進入的物件取出（佇列為FIFO）
            reuse.transform.position = position;//接收參數的位置
            reuse.transform.rotation = rotation;//接收參數的角度
            reuse.SetActive(true);//關閉物件
        }
        else//物件池內無物件時
        {
            GameObject go = Instantiate(prefab) as GameObject;//直接生成新物件
            go.transform.position = position;
            go.transform.rotation = rotation;
        }
    }


    public void Recovery(GameObject recovery)//回收利用
    {
        objPool.Enqueue(recovery);//把外面的物件收進物件池
        recovery.SetActive(false);//設定不啟用
    }
}