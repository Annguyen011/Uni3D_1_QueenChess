using UnityEngine;


public class Cell : MonoBehaviour
{
    #region [Elements]

    [Header("# Settings")]
    [SerializeField] private Transform cellHolder;

    [Header("# Color infos")]
    [SerializeField] private ECellColor color;
    [SerializeField] private ECellState state;
    public ECellState State
    {
        get { return state; }
        set
        {
            state = value;

            switch (state)
            {
                case ECellState.NORMAL:
                    cellHolder.gameObject.SetActive(false);
                    break;
                case ECellState.HOLDER:
                    cellHolder.gameObject.SetActive(true);
                    break;
                case ECellState.SELECT:
                    break;
                case ECellState.TARGET:
                    break;

            }
        }
    }



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

    private void Start()
    {
        cellHolder = transform.Find("Holder");
        cellHolder.gameObject.SetActive(false);

        state = ECellState.NORMAL;
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

    public void SetCellState(ECellState state)
    {
        State = state;
    }
}
