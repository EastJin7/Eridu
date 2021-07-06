using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class zerocontrol : MonoBehaviour
{

    public bool facingRight = true;//是否面對右方

    public float jumpforce = 200f;
    public bool jump;
    //public AudioClip[] jumpClips;

    private const string idle = "Idle";
    private const string atk1 = "attank";
    private const string atk2 = "attank2";
    private const string atk3 = "attank3";
    private const string dmg = "hurt";
    public AudioClip huSe;
    public AudioClip clSe;
    private const string clear = "clear";
    private const string skill_1 = "skill";
    private int fcount = 0;//攻擊段數
    public AnimatorStateInfo animStateInfo;
    public bool hAtk;//重擊
    private bool hAtkIng;

    public float maxHp = 100f;//生命值
    public float nowHp;
    private float defence = 0;

    public bool invincible = false;//是否無敵
    private bool canmove = true;//是否可移動
    public float delaytime;
    private float cantmovetime;
    private bool f3 = false;

    public Weapon weapon;
    public ClearEffect clearef;
    public ObjectPool pool;
    public Vector3 pos;
    public JoyStick js;
    public HUD hud;
    public SavePlayerPrefs save;
    public UseItem useItem;

    public bool grounded = false;//地板確認，預設為不在地上
    private Transform groundCheck;//命名一個叫做groundCheck的位置
    public AudioClip jumpSe;

    public Animator anim; // 命名一個Animator叫做anim
    public Rigidbody2D body; // 命名一個2D鋼體叫做body

    public bool over = false;//是否Gameover
    public bool done = false;//此關卡是否完成
    protected Scene scene;
    bool cantalk = false;
    public bool talkOpen = false;

    public SoundManager sm;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>(); //獲得Animator在我們命名的anim裡
        body = GetComponent<Rigidbody2D>(); //獲得剛體在我們命名的body裡

        weapon = GameObject.FindObjectOfType<Weapon>();
        clearef = GameObject.FindObjectOfType<ClearEffect>();

        js = GameObject.FindObjectOfType<JoyStick>();//找到虛擬搖桿
        js.OnJoyStickTouchBegin += OnJoyStickBegin;
        js.OnJoyStickTouchMove += OnJoyStickMove;
        js.OnJoyStickTouchEnd += OnJoyStickEnd;

        hud = GameObject.FindObjectOfType<HUD>();
        
        nowHp = maxHp;//遊戲開始時血量為滿值
        GameState.gameover = false;//重讀此畫面時回到最初狀態
        GameState.gamepause = false;//重讀此畫面時取消暫停狀態
        GameState.victory = false;//重讀此畫面時取消勝利狀態
        scene = SceneManager.GetActiveScene();
    }
    // Update is called once per frame
    void Update()
    {
        anim.transform.rotation = Quaternion.Euler(0, 0, 0); //凍結主角角度，不可旋轉
        //Debug.DrawLine(transform.position, groundCheck.position, color.red, 1f);
        if (Input.GetKeyDown(KeyCode.Space))//輸入跳躍鍵
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.F))//地面攻擊
        {
            body.velocity = new Vector2(0, body.velocity.y);
            Atk();
        }
        if (Input.GetKeyDown(KeyCode.G))//重擊
        {
            //hAtk = true;
            HAtk();
        }
        animStateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (!animStateInfo.IsName(idle)&& animStateInfo.normalizedTime > delaytime)
        {
            fcount = 0;//在下一幀開始前將參數清空避免連續切換
            anim.SetInteger("Atk", 0);
            f3 = false;
            cantmovetime = 0.3f;
            StartCoroutine(CantMove());
        }
        if (animStateInfo.IsName(atk1) || animStateInfo.IsName(atk2) || animStateInfo.IsName(atk3) || animStateInfo.IsName(dmg) || animStateInfo.IsName(clear) || animStateInfo.IsName(skill_1))
        {
            canmove = false;
        }
        if (nowHp <=0)
        {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.Q))//展示用金手指
        {
            useItem.UseThis();
        }

    }
    public void Atk()
    {
        if (!GameState.gamepause)
        {
            if (!cantalk)
            {
                GameState.sword++;
                GameState.allSword++;
                if (animStateInfo.IsName(idle) && fcount == 0)
                {
                    anim.SetInteger("Atk", 1);
                    fcount = 1;
                    weapon.Enabled(1);//武器碰撞有效化
                    delaytime = 0.6f;
                }
                if (animStateInfo.IsName(atk1) && fcount == 1 && animStateInfo.normalizedTime > 0.35f)
                {
                    anim.SetInteger("Atk", 2);
                    fcount = 2;
                    weapon.Enabled(2);//武器碰撞有效化
                    delaytime = 0.9f;
                }
                if (animStateInfo.IsName(atk2) && fcount == 2 && !f3)//&& animStateInfo.normalizedTime > 0.85f
                {
                    f3 = true;//不可重複兩次第三段攻擊
                    anim.SetInteger("Atk", 3);
                    fcount = 3;
                    weapon.Enabled(3);//武器碰撞有效化
                    delaytime = 0.7f;
                }
                canmove = false;//不可移動
            }
            if(cantalk)
            {
                talkOpen = true;
            }
        }
    }
    public void HAtk()
    {
        if (!GameState.gamepause && !hAtkIng)
        {
            if (animStateInfo.IsName(idle) && GameState.clearLv >= 1)//
            {
                anim.SetInteger("Atk", 0);
                anim.SetBool("clear",true);
                sm.PlaySE(clSe);
                hAtkIng = true;
                cantmovetime = 0.8f;
                StartCoroutine(CantMove());//延遲恢復可以移動
                StartCoroutine(HAtkCD(0));
                GameState.tryCle++;
                GameState.allTryCle++;
            }
            if (animStateInfo.IsName(atk1) && GameState.skill1Lv >= 1)//
            {
                SwordHAtk();
            }
        }
    }
    void SwordHAtk()
    {
        anim.SetTrigger("skill");
        hAtkIng = true;
        if (facingRight)
        {
            pos = this.transform.position + new Vector3(0.3f, 0f);
        }
        if (!facingRight)
        {
            pos = this.transform.position + new Vector3(-0.3f, 0f);
        }
        pool.ReUse(pos, transform.rotation);
        cantmovetime = 0.4f;
        StartCoroutine(CantMove());//延遲恢復可以移動
        StartCoroutine(HAtkCD(1));
    }
    IEnumerator HAtkCD(int id)
    {
        float hAtkCd = 1f;
        switch(id)
        {
            case 0:
                hAtkCd = 3f;
                break;
            case 1:
                hAtkCd = 5f;
                break;
        }
        yield return new WaitForSeconds(hAtkCd);
        hAtkIng = false;
    }

        //RaycastHit2D hit = Physics2D.Raycast(this.transform.position, transform.right, 30f, 512);
        //射線偵測 初始位置,方向,距離,圖層遮罩(2進位數值)

    IEnumerator CantMove()
    {
        yield return new WaitForSeconds(cantmovetime);
        canmove = true;
        anim.SetBool("clear", false);
    }
        public void Jump()//跳的時候
    {
        if (grounded)//確認在地上時
        {
            jump = true;//跳
        }
    }

    void OnCollisionStay2D(Collision2D collider)//碰撞持續時
    {
        CheckIfGrounded();//執行函式CheckIfGrounded
    }
    void OnCollisionExit2D(Collision2D collider)//碰撞離開時
    {
        grounded = false;//設定不在地面上
    }
    private void CheckIfGrounded()//CheckIfGrounded函式
    {
        RaycastHit2D[] hits; //設一射線空間
        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, Vector3.down, 0.01f);
        //從主角向下繪製射線空間
        if (hits.Length > 0)
            //RaycastHit2D hit = Physics2D.Raycast(positionToCheck, new Vector2(0, -1), 0.1f, groundMask);
            //if (hit)
        {
            grounded = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");//獲得horizontal水平輸入到h變量中
        Move(h);
        if (jump == true && !GameState.gameover && !GameState.gamepause)//按下跳躍的時候
        {
            //zero.SetTrigger("Jump");//太難用，註解掉
            if (h>0)
            {
                body.velocity = new Vector2(body.velocity.x, 0);
                anim.Play("jump");//播放跳躍動畫
            }
            else
            {
                body.velocity = new Vector2(0, 0);
                anim.Play("stayjump");
            }
            sm.PlaySE(jumpSe,0.8f);
            body.AddForce(new Vector2(0f, jumpforce));//添加剛體力
            jump = false;
        }
        if (GameState.gameover==true || GameState.gamepause==true)
        {
            body.velocity = Vector3.zero;
            anim.SetFloat("Speed", 0f);
            return;
        }
    }

    public void Move(float h)
    {
        if (!GameState.gameover && !GameState.gamepause)
        {
            if (canmove == true)
            {
                anim.SetFloat("Speed", Mathf.Abs(h));//將水平輸入的變量絕對值後設到動畫中的變數Speed
                                                     //            if (h != 0 && jump==false) { anim.Play("run"); }
                if (h > 0) { transform.Translate(Vector2.right * Time.deltaTime * 1.4f); }//當h為正數時依照時間向右移
                if (h < 0) { transform.Translate(Vector2.left * Time.deltaTime * 1.4f); }//當h為負數時依照石尖巷左移
                                                                                         //Debug.Log(h);
            }
            if (h > 0 && !facingRight)
            {
                Flip();//呼叫轉身函式
            }
            else if (h < 0 && facingRight)
            {
                Flip();
            }
        }
    }
    void Flip()//轉身函式
    {
        facingRight = !facingRight;//面向右方變面向左方
        //transform.rotation = Quaternion.Euler(0, 90, 0);
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;//把Scale從1變成-1或1變成-1
    }

    public void Die()//死亡函式
    {
        if (!GameState.gameover) {
            GameState.gameover = true;
            anim.SetTrigger("hurt");
            anim.SetTrigger("gameover");//播放死亡動畫
            GameState.dead++;
            StartCoroutine(AfterDie());
        }
    }
    IEnumerator AfterDie()//死亡後重新讀取延時方法
    {
        save.GameOver();
        yield return new WaitForSeconds(2f);
        AsyncOperation async = SceneManager.LoadSceneAsync(scene.name);
        //Application.LoadLevel(Application.loadedLevel);//死亡時重新開始
    }
    public void Hurt(float hurt)
    {
        if (invincible == false && !GameState.gameover && !GameState.gamepause)
        {
            canmove = false;//受傷時短暫無法移動，避免又受傷一次
            anim.SetTrigger("hurt");//觸發hurt動作
            sm.PlaySE(huSe,0.95f);
            hurt -= defence;
            nowHp -= hurt;
            hud.Coruscate();
            Invincible();
            if (facingRight)
            {
                body.velocity = new Vector2(0, 0);
                body.AddForce(new Vector2(-110f, 0f));//後退
            }
            else
            {
                body.velocity = new Vector2(0, 0);
                body.AddForce(new Vector2(110f, 0f));//後退
            }
            cantmovetime = 1f;
            StartCoroutine(CantMove());//延遲恢復可以移動
        }
    }
    public void Invincible()
    {
        invincible = true;
        this.gameObject.layer = 8;
        StartCoroutine(EndInvincible());//延遲執行無敵解除函式
    }
    IEnumerator EndInvincible()//無敵的延時方法
    {
        this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 100, 255);//無敵顏色變黃
        yield return new WaitForSeconds(2f);//無敵時間
        this.gameObject.layer = 13;
        invincible = false;//無敵結束
        this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    void OnJoyStickBegin(Vector2 vec)
    {
        //開始觸摸虛擬搖桿
    }
    void OnJoyStickMove(Vector2 vec)
    {
        float h = 0.5f;
        if (vec.x > 0.3f)
        {
            Move(h);
        }
        if (vec.x < -0.3f)
        {
            Move(-h);
        }

        float j = vec.y;
        if (j >= 0.7f)
        {
            Jump();
            js.GetZero();
        }
    }
    void OnJoyStickEnd()
    {
        //觸摸移動搖桿結束
    }
    void OnClickMoveBegin(bool d, bool t)
    {
        if (t == true)
        {
            float h = 0.5f;
            if (d == true)
            {
               Move(h);
            }
            else
            {
                Move(-h);
            }
        }
    }
    void OnMoveEnd(bool t)
    {
        if(t==false)
        {
            Move(0);
        }
    }
    void GoldFinger()//展示用金手指
    {
        nowHp = 100;
    }
    public void NPCTalk(bool b)
    {
        cantalk = b;
    }
    public void HAtkPress()
    {
        HAtk();
    }
    public void PlusDefence(int p)
    {
        defence += p;
    }
    public bool Cure(int plushp)
    {
        if(nowHp < maxHp && nowHp>=0)
        {
            float deHp = maxHp - nowHp;
            if(deHp >= plushp)
            {
                nowHp += plushp;
            }
            else
            {
                nowHp += deHp;
            }
            return true;
        }
        else//nowHp>=maxHp
        {
            return false;
        }
    }
}
