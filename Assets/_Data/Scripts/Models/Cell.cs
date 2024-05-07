using UnityEngine;


public class Cell : MonoBehaviour
{
	#region [Elements]

	[Header("# Color infos")]
	[SerializeField] private ECellColor color;
	[SerializeField] private Transform white;
	[SerializeField] private Transform black;
	[SerializeField] private ECellState state;

    #endregion


    #region [Components]



    #endregion

    #region [Unity Methods]

    private void Start()
    {
        white.gameObject.SetActive(false);
        black.gameObject.SetActive(false);

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
                black.gameObject.SetActive(true);
                break;

            case ECellColor.WHITE:
                white.gameObject.SetActive(true);
                break;
        }
    }

    #endregion

    #region [Override]



    #endregion

}
