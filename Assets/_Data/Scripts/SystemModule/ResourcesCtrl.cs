using UnityEngine;


public class ResourcesCtrl : MonoBehaviour
{
    #region [Elements]



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
    }

    #endregion

    #region [Override]



    #endregion

}
