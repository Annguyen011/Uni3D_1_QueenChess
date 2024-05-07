using UnityEngine;


public class Cell : MonoBehaviour
{
	#region [Elements]

	[Header("# Color infos")]
	[SerializeField] private ECellColor color;
	[SerializeField] private ECellState state;

    #endregion


    #region [Components]



    #endregion

    #region [Unity Methods]

    private void Start()
    {
        SetColor();
    }
    /// <summary>
    /// Set color when game start
    /// </summary>
    private void SetColor()
    {
        switch (color)
        {
            case ECellColor.BLACK:
                gameObject.GetComponent<Renderer>().material = 
                    ResourcesCtrl.Instance.blackMaterial;
                break;

            case ECellColor.WHITE:
                gameObject.GetComponent<Renderer>().material = 
                    ResourcesCtrl.Instance.whiteMaterial;
                break;
        }
    }

    #endregion

    #region [Override]



    #endregion

}
