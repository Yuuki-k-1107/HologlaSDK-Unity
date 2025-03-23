using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUninitialized : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var initial0 = PlayerPrefs.GetInt("Initial0");
        Debug.Log($"åªç›ÇÃInitial0ÇÃílÇÕ{initial0}Ç≈Ç∑ÅB");
#if UNITY_EDITOR || true
        PlayerPrefs.SetInt("Initial0", 0);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
