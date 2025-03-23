using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaunchManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        MayShowInitMenu();
    }

    public void MayShowInitMenu()
    {
        var initial0 = PlayerPrefs.GetInt("initial0");
        if(initial0 == 0)
        {
            if(null != _animator)
            {
                _animator.SetTrigger("ViewModeMenuIn");
            }
        }
    }

    public void UnsetInitial0()
    {
        PlayerPrefs.SetInt("initial0", 1);
    }
}
