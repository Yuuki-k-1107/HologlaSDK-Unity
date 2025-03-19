using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectDecisionBlockAbstract : MonoBehaviour
{
    [SerializeField] protected InitializationManager _initializationManager;
    [SerializeField] protected GameObject decisionBlockNormal;
    [SerializeField] protected GameObject decisionBlockInit;
}
public class SelectDecisionBlock : SelectDecisionBlockAbstract
{
    //[SerializeField] private InitializationManager _initializationManager;
    //[SerializeField] private GameObject decisionBlockNormal;
    //[SerializeField] private GameObject decisionBlockInit;
    private void OnEnable()
    {
        if(true == _initializationManager.isInitializing)
        {
            decisionBlockInit.SetActive(true);
            decisionBlockNormal.SetActive(false);
        }
        else
        {
            decisionBlockInit.SetActive(false);
            decisionBlockInit.SetActive(true);
        }
    }
    void Start()
    {
        if(null == _initializationManager)
        {
            _initializationManager = transform.root.GetComponent<InitializationManager>();
        }
    }

    void Update()
    {
        
    }
}
