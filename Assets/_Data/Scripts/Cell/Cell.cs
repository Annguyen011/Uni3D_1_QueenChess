using UnityEngine;


public class Cell : MonoBehaviour
{
    #region [Elements]

    [Header("# Settings")]
    [SerializeField] private Transform cellHolder;
    [SerializeField] private BasePiece curPiece;
    [SerializeField] private Transform cellSelected;

    [Header("# Color infos")]
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
                    cellSelected.gameObject.SetActive(false);
                    break;
                case ECellState.SELECT:
                    cellSelected.gameObject.SetActive(true);
                    cellHolder.gameObject.SetActive(false);

                    curPiece.BeSelected();

                    break;
                case ECellState.TARGET:
                    cellSelected.gameObject.SetActive(false);
                    cellHolder.gameObject.SetActive(true);
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
        cellSelected = transform.Find("Selected");

        cellHolder.gameObject.SetActive(false);
        cellSelected.gameObject.SetActive(false);

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
    /// <summary>
    /// Dat lai stateWantChange cho cell
    /// </summary>
    /// <param name="stateWantChange"></param>
    public void SetCellState(ECellState stateWantChange)
    {

        switch (stateWantChange)
        {
            case ECellState.NORMAL:
                this.State = stateWantChange;
                break;
            case ECellState.SELECT:
                if(!curPiece)
                {
                    return;
                }
                State = stateWantChange;
                break;
            case ECellState.TARGET:
                State = stateWantChange;
                break;

        }


        //if (stateWantChange != ECellState.SELECT)
        //{
        //    if (State != ECellState.SELECT)
        //    {
        //        State = stateWantChange;
        //    }
        //}

        //else
        //{
        //    if (State == ECellState.SELECT)
        //    {
        //        State = ECellState.HOLDER;
        //    }
        //    else if (curPiece)
        //    {
        //        State = ECellState.SELECT;
        //    }
        //    else
        //    {
        //        State = ECellState.NORMAL;
        //    }
        //}

        //if (stateWantChange == ECellState.UNSELECT)
        //{
        //    State = ECellState.UNSELECT;
        //}

        //if(stateWantChange == ECellState.TARGET)
        //{
        //    State = ECellState.TARGET;
        //}
    }

    public void SetPiece(BasePiece piece)
    {
        curPiece = piece;
    }

    public BasePiece GetPiece() => curPiece;
}
