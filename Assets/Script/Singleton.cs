/**********************************************************
// Author   : K.(k79k06k02k)
// FileName : Singleton.cs
// Reference: http://wiki.unity3d.com/index.php/Singleton
**********************************************************/
//為了讓不同類別之中可以跨類別存取，方便呼叫

public class Singleton<T> where T : class, new()
{
    private static T _instance;

    private static object _lock = new object();

    public static T Instance
    {
        get
        {
            //多執行緒
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }
    }
}