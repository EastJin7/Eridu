using UnityEngine;
using System.Collections;

public class PatrolAI : MonoBehaviour
{
    public float movePos=3f;//移動座標由編輯器指定 
    float startPos; //起始座標
    float endPos; //結束座標
    float moveSpeed = 0.5f;//移動速度
    bool moveRight = true;//是否往右移動
    Rigidbody2D body;

    void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
        endPos = startPos + movePos;
    }

    void Update()
    {
        if (moveRight)
        {
            body.position += Vector2.right * moveSpeed * Time.deltaTime;
        }
        if (body.position.x >= endPos)
        {
            moveRight = false;
        }
        if (moveRight == false)
        {
            body.position -= Vector2.right * moveSpeed * Time.deltaTime;
        }
        if (body.position.x <= startPos)
        {
            moveRight = true;
        }
    }
}