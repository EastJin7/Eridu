using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Cameras
{
    [ExecuteInEditMode]
    public class CameraToWall : MonoBehaviour
    {
        public float baseWidth = 1024;//開發時定義的基礎解析度寬度
        public float baseHeight = 602;//開發時定義的基礎解析度高度

        private float baseAspect;//開發時定義的基礎解析度長寬比
        private float targetAspect;//實際顯示畫面的長寬比
        private float m03;//實際畫面上，GUI的 x 軸起始點為從左邊算來第幾個像素(pixel)
        private float m13;//實際畫面上，GUI的 y 軸起始點為從上方算來第幾個像素(pixel)
        private float m33;//x 軸及 y 軸等比縮放比例的反比，也就是說，數值變大為等比縮小，數值變小則等比放大。

        public Transform target;
        private float distance = 10.0f;//距離
        private float height = 0.4f;//高度差
        private float width = 0.6f;//寬度差
        private float zaxis = -0.1f;//Z軸差
        public float heightDamping = 2.0f;//平滑高度的速度
        private bool stopFollow = false;
        int wallMask;

        void Awake()
        {
            wallMask = LayerMask.GetMask("Wall");
            float targetWidth = (float)Screen.width;
            float targetHeight = (float)Screen.height;

            this.baseAspect = this.baseWidth / this.baseHeight;
            this.targetAspect = targetWidth / targetHeight;

            float factor = this.targetAspect > this.baseAspect ? targetHeight / this.baseHeight : targetWidth / this.baseWidth;
            //假設檢視空間垂直大小需要乘以一個轉換因子(factor)之後會得到我們期望的畫面解析度垂直大小，求轉換因子factor

            this.m33 = 1 / factor;//由於 GUI.matrix.m33 是等比縮放比例的反比，所以可以這樣指定新的值給它
            this.m03 = (targetWidth - this.baseWidth * factor) / 2 * this.m33;//如果 targetAspect 比較大，表示畫面變寬了，所以我們需要改變 GUI 的 x 軸起始點。
            this.m13 = (targetHeight - this.baseHeight * factor) / 2 * this.m33;//如果 targetAspect 比較小，代表畫面變長了，所以我們需要改變 GUI 的 y 軸的起始點。
        }
        void Update()
        {
            RaycastHit2D hitr = Physics2D.Raycast(target.transform.position, Vector3.right, 1.6f, wallMask);
            RaycastHit2D hitl = Physics2D.Raycast(target.transform.position, Vector3.left, 1.6f, wallMask);
            if (hitr || hitl)
            {
                stopFollow = true;
            }
            else
            {
                stopFollow = false;
            }
        }


        void LateUpdate()
        {
            if (!target) return;
            float wantedHeight = target.position.y + height; //想要的高度為目標高度+高度
            float currentHeight = transform.position.y;

            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            if (!stopFollow)
            {
                transform.position = target.position;
                transform.position -= Vector3.forward * distance;

                // 設定camera的高度
                transform.position = new Vector3(transform.position.x, currentHeight, -1f);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }
}


