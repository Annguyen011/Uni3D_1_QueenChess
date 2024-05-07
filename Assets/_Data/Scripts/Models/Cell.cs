using UnityEngine;


public class Cell : MonoBehaviour
{
    #region [Elements]

    [Header("# Color infos")]
    [SerializeField] private ECellColor color;
    [SerializeField] private ECellState state;

    [Header("# Cell infos")]
    public float size;
    #endregion

    #region [Components]

    private Renderer ren;

    #endregion

    #region [Unity Methods]

    private void Awake()
    {
        ren = GetComponent<Renderer>();
        size = ren.bounds.size.x;
    }

    #endregion

    #region [Override]



    #endregion

    /// <summary>
    /// Set color when game start
    /// </summary>
    public void SetColor(ECellColor color)
    {
        this.color = color;

        switch (color)
        {
            case ECellColor.BLACK:
                ren.material = ResourcesCtrl.Instance.blackMaterial;
                break;

            case ECellColor.WHITE:
                ren.material = ResourcesCtrl.Instance.whiteMaterial;
                break;
        }
    }
}
