using System;
using UnityEngine;


public class ResourcesCtrl : MonoBehaviour
{
    #region [Elements]

    public Material blackMaterial;
    public Material whiteMaterial;
    public Material holderMaterial;

    #endregion


    #region [Components]

    public static ResourcesCtrl Instance;

    #endregion

    #region [Unity Methods]

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        LoadResources();
    }


    #endregion

    #region [Override]



    #endregion

    private void LoadResources()
    {
        blackMaterial = Resources.Load<Material>("Materials/Black");
        whiteMaterial = Resources.Load<Material>("Materials/White");
        holderMaterial = Resources.Load<Material>("Materials/Holder");
    }
}
