using UnityEngine;

public class Test : MonoBehaviour
{
    public static bool isSound = false; 
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
