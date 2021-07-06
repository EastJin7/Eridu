using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
    public zerocontrol player;
    public Rigidbody2D body;
    public Weapon weapon;
    public Animator anim; // 命名一個怪物用Animator叫做anim
    private AnimatorStateInfo animStateInfo;//怪物動畫狀態
    public SoundManager sm;
    public AudioClip ju;
    public AudioClip deadSe;
    public SavePlayerPrefs save;
    public BossHUD hud;
    //public GameObject damageup;
    //public Camera FollowCamera;

    public float monsAtk;//本怪物攻擊力，從編輯器指定
    public float fullHp; //本怪物血量，從編輯器指定
    public float defence;//本怪物防禦力，從編輯器指定
    public bool spec = false;//本怪物是否為特殊怪物
//被攻擊
    public float myHp; //目前血量
    float hurt = 10;  //從weapon指定的傷害值
    float deHp; //扣除防禦後獲得的真正傷害
    int fcount; //記錄weapon傳入的攻擊段數參數
    bool direction; //主角攻擊方向，從weapon獲取參數後記錄
    bool facingRight = false;   //本怪物的面向，預設是false
    float changex;  //被打時x軸移動
    float changey;  //被打時y軸移動
    bool beHurt; //避免重複傷害判斷
    public bool monDie = false;//本怪物是否已死亡。避免玩家虐屍(X)
    bool monWarn = false;//本怪物是否被攻擊進入緊戒狀態
    public ObjectPool pool;//死亡掉落物品
    //被淨化
    int mySour;//目前靈魂
    //public GameObject pool2;淨化掉落物
    bool clear = false;//淨化(擊暈)用。預設為false，被淨化了才會變true
    //巡邏AI
    public float movePos;//移動座標，由編輯器指定
    float startPos; //起始座標
    float endPos; //結束座標
    float moveSpeed = 0.5f;//移動速度
    bool moveRight = true;//是否往右移動
//攻擊AI
    float lastTime = 0.0f;
    float waitTime = 1.5f;//攻擊間隔時間
    public float atkRange = 0.8f;//本怪物攻擊距離
    Vector2 playerPosition;
    Vector2 monsterPosition;
    private const string dmg = "hurt";

    void Awake()
    {
        if (spec)
        {
            hud = GameObject.FindObjectOfType<BossHUD>();
        }
        this.gameObject.tag = "Monster";
        anim = this.GetComponent<Animator>();//獲取動畫資訊
        animStateInfo = anim.GetCurrentAnimatorStateInfo(0);//獲取動畫狀態
        this.gameObject.SetActive(true);//啟用整個物件
        player = GameObject.FindObjectOfType<zerocontrol>();
        weapon = GameObject.FindObjectOfType<Weapon>();
        monsterPosition = transform.position;
        body = GetComponent<Rigidbody2D>();//獲取剛體
        //damageup = GameObject.FindObjectOfType<DamageUp>();//找到浮動傷害
        myHp = fullHp;//重置血量
        mySour = 3;//重置靈魂量
        clear = false;//重置淨化狀態
        monDie = false;//重置死亡狀態
        monWarn = false;//重置警戒狀態
        startPos = transform.position.x;//獲取起始座標
        endPos = startPos + movePos;//巡邏終點為起始座標+移動座標
        if (spec) { monWarn = true; }

    }
     void WeaponEnter()
    {
        hurt = weapon.dmg;
        fcount = weapon.fcount;
        direction = weapon.atkright;
    }
    IEnumerator Hurt()
    {
        //DamageUp oObject = Instantiate(damageup, this.transform.position, Quaternion.identity) as DamageUp;//生成浮動傷害
        //damageup.Hit(hurt);//浮動傷害顯示hurt數字
        switch (fcount)
        {
            case 1:
                changex = 30f;
                changey = 60f;
                deHp = hurt - defence;
                break;
            case 2:
                changex = 10f;
                changey = 50f;
                deHp = hurt - defence;
                break;
            case 3:
                changex = 30f;
                changey = 100f;
                deHp = hurt - defence;
                break;
            case 4:
                changex = 50f;
                changey = 60f;
                deHp = hurt - defence;
                break;
        }
        deHp = (int)deHp;//轉換成int
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Retreat());
    }
    void IfHurt()        //是否死亡
    {
        if (myHp <= 0)//當目前HP<=0
        {
            body.AddForce(new Vector2(0f, 0.4f));//往上飛
            StartCoroutine(Die());//執行死亡函式
            return;//結束所有動作，避免多次觸發死亡
        }
    }

    IEnumerator Retreat()
    {
        anim.Play("hurt");
        myHp -= deHp;
        Debug.Log(myHp);
        if (spec)
        {
            hud.Coruscate();
        }
        body.velocity = new Vector2(0, 0);
        beHurt = false;
        lastTime = Time.time;//被打就重置攻擊時間
        //damageup.GetComponent<DamageUp>().damage = (int)hurt;//顯示的浮動傷害是轉換為整數後的hurt
        //GameObject oObject = (GameObject)Instantiate(damageup, transform.position, Quaternion.identity);//生成浮動傷害
        if (direction == true)//主角是向右攻擊
        {
            if (facingRight)//若怪物面對右邊
            {
                Filp();//轉向左

            }
            body.AddForce(new Vector2(changex, changey));//後退
        }
        else
        {
            if (!facingRight)//若怪物面對左邊
            {
                Filp();//轉向右
            }
            body.AddForce(new Vector2(-changex, changey));//後退
        }
        yield return new WaitForSeconds(0.2f);
        monWarn = true;//開啟警戒模式
        IfHurt();
    }

    IEnumerator BeClear()
    {
        yield return new WaitForSeconds(0.1f);
        anim.Play("hurt");
        mySour -= 1;
        body.velocity = new Vector2(0, 0);
        lastTime = Time.time;//重置攻擊時間
        if (direction == true)
        {
            if (facingRight)
            {
                Filp();
            }
        }
        else
        {
            if (!facingRight)
            {
                Filp();
            }
        }
        body.AddForce(new Vector2(0, 30f));//跳起
        yield return new WaitForSeconds(0.2f);
        monWarn = true;//開啟警戒模式
        yield return new WaitForSeconds(1f);
        beHurt = false;
        IfClear();
    }
    void IfClear()        //是否淨化結束
    {
        if (mySour <= 0 && myHp<= 60 && !clear && !spec)
        {
            body.AddForce(new Vector2(0f, 40f));//往上飛
            StartCoroutine(Cleared());
            return;
        }
        if (mySour <= 0 && myHp <= 30 && !clear && spec)
        {
            body.AddForce(new Vector2(0f, 40f));//往上飛
            StartCoroutine(Cleared());
            return;
        }
    }

    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        //        damageup.DamagePoint(hurt, this.transform.position, mainCamera);
    //        GameObject mObject = (GameObject)Instantiate(damageup, transform.position, Quaternion.identity);
    //        mObject.GetComponent<DamageUp>().damage=hurt;
    //    }
    //}

    void Filp()
    {
        facingRight = !facingRight;//面向右方變面向左方
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;//把Scale從1變成-1或1變成-1
    }
    void Update()
    {
        //巡邏
        if (!monDie && !monWarn && !spec && !GameState.gamepause)//非死亡或警戒時
        {
            PatrolState();
        }
        //警戒
        if (monWarn && !monDie && !clear && !GameState.gamepause)
        {
            playerPosition = player.transform.position;//獲取玩家位置
            monsterPosition = this.transform.position;
            MonsWarnState();//進入緊戒狀態
        }
    }
    void PatrolState()//巡邏模式
    {
        if (moveRight)//向右走
        {
            if (!facingRight) { Filp(); }//不面對右邊就轉身
            body.position += Vector2.right * moveSpeed * Time.deltaTime;
        }
        if (body.position.x >= endPos)//走到終點
        {
            moveRight = false;
        }
        if (moveRight == false)//向左走
        {
            if (facingRight) { Filp(); }//不面對左邊就轉身
            body.position += Vector2.left * moveSpeed * Time.deltaTime;
        }
        if (body.position.x <= startPos)//走回起點
        {
            moveRight = true;
            Filp();
        }
    }
    void MonsWarnState()//警戒模式
    {

        Vector2 distance = monsterPosition - playerPosition;//獲取與玩家的距離(ve2)
        float dis = Vector2.Distance(monsterPosition, playerPosition);//計算成float距離
        if (dis >= 3f && !spec)
        {
            if (body.position.x <= startPos)
            {
                body.position = new Vector2(startPos + 0.1f, body.position.y);
                moveRight = false;
            }
            if (body.position.x >= endPos)
            {
                body.position = new Vector2(endPos - 0.1f, body.position.y);
                moveRight = true;
            }
            monWarn = false;
            //PatrolState();
        }
        if (dis < 3f && dis > atkRange)//在距離>攻擊距離(預設0.8)且<3時
        {
            transform.position = (Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime));
            //依畫幀更新時間和巡邏速度朝主角前進
            if (transform.position.x < player.transform.position.x && !facingRight)
            {
                Filp();//如果主角在右邊而怪物不面對右邊則轉身
            }
            if (transform.position.x > player.transform.position.x && facingRight)
            {
                Filp();//如果主角在左邊而怪物不面對左邊則轉身
            }
        }
        if (dis < atkRange)
        {//當距離在攻擊範圍內
            if (Time.time - lastTime >= waitTime)//當計時器跑了waitTime秒
            {
                lastTime = Time.time;//時間更新
                if (!animStateInfo.IsName(dmg))//不處於受傷動畫時
                {
                    MonsAtk();//進行攻擊
                }
            }
    }
}
    void MonsAtk()
    {
        anim.SetTrigger("jump");
        sm.PlaySE(ju,0.5f);
        if (!spec)
        {
            if (facingRight)
                body.AddForce(new Vector2(50f, 120f));
            else
                body.AddForce(new Vector2(-50f, 120f));
        }
        else
        {
            if (facingRight)
                body.AddForce(new Vector2(80f, 160f));
            else
                body.AddForce(new Vector2(-80f, 160f));
        }
    }
    IEnumerator Die()
    {
        anim.SetTrigger("die");
        monDie = true;
        yield return new WaitForSeconds(0.9f);
        this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 127);
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 70);
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 23);
        sm.PlaySE(deadSe);
        pool.ReUse(monsterPosition + new Vector2(0, 0.5f), Quaternion.identity);
        if(spec)
        {
            pool.ReUse(monsterPosition + new Vector2(0, 0.5f), Quaternion.identity);
            pool.ReUse(monsterPosition + new Vector2(0, 0.5f), Quaternion.identity);
        }
        this.gameObject.SetActive(false);
        GameState.killa++;//擊殺數+1
        GameState.allKillA++;
        Debug.Log(GameState.killa);
        GameState.slimeKill++;
        if (spec && monDie)
        {
            GameState.victory = true;
            GameState.coins += 30;
            save.VictoryTotal();
        }
        Destroy(this.gameObject);
    }
    IEnumerator Cleared()
    {
        clear = true;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("clear", true);
        sm.PlaySE(deadSe);
        GameState.cleara++;
        GameState.allClearA++;
        Debug.Log(GameState.cleara);
        this.gameObject.tag = "NPC";
        if (spec && clear)
        {
            GameState.victory = true;
            GameState.coins += 30;
            save.VictoryTotal();
        }
    }

    void OnTriggerEnter2D(Collider2D other)//被玩家攻擊
    {
        if (other.tag == "Weapon" && !monDie && !clear && !beHurt)//被武器打到
        {
            beHurt = true;
            WeaponEnter();//獲得武器上的數值
            StartCoroutine(Hurt());//執行受傷程式
            return;
        }
        if (other.tag == "Clear" && !monDie && !clear)
        {
            beHurt = true;
            StartCoroutine(BeClear());
            return;
        }
        if (other.tag =="Skill" && !monDie && !clear)
        {
            if(other.name == "swordEffect(Clone)")//若產生碰撞的物件名稱為swordEffect
            {
                hurt = 40;
                fcount = 4;
                if(other.transform.position.x > transform.position.x) { direction = false; }//碰撞目標在右邊，則代表主角面對左邊
                if(other.transform.position.x < transform.position.x) { direction = true; }
                if (!beHurt)
                {
                    StartCoroutine(Hurt());//執行受傷程式
                    beHurt = true;
                    return;
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)//撞到玩家
    {
        if (other.tag == "Player" && clear==false && !monDie && !GameState.gameover)
        {
            player.Hurt(monsAtk);
            return;
        }
    }
}
