using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    #region VARIABLES
    private const string SingletonTag = "(Singleton)";

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    instance = new GameObject(typeof(T).Name + SingletonTag).AddComponent<T>();
                }
            }

            return instance;
        }
    }
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            instance.name = typeof(T).Name + SingletonTag;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
}