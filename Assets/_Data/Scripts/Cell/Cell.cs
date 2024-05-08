using UnityEngine;

public class Cell : MonoBehaviour
{
    #region [Elements]

    [Header("# Settings")]
    public Vector2 location;
    public BasePiece curPiece;
    [SerializeField] private Transform cellSelected;

    [Header("# Color infos")]
    [SerializeField] private ECellState state;
    public ECellState State
    {
        get { return state; }
        set
        {
            state = value;

            // Xác định hành động cần thực hiện dựa trên trạng thái của ô
            switch (state)
            {
                case ECellState.NORMAL:
                    cellSelected.gameObject.SetActive(false);

                    //if(curPiece)
                    //{
                    //    curPiece.BeUnselected();
                    //}
                    break;
                case ECellState.SELECT:
                    cellSelected.gameObject.SetActive(true);
                    curPiece.BeSelected(); // Gọi hàm BeSelected() từ curPiece
                    break;
                case ECellState.TARGET:
                    cellSelected.gameObject.SetActive(true);
                    break;
            }
        }
    }

    #endregion

    #region [Components]

    private Renderer ren;

    #endregion

    #region [Unity Methods]

    private void Awake()
    {
        ren = GetComponent<Renderer>();
    }

    private void Start()
    {
        cellSelected = transform.Find("Selected");

        cellSelected.gameObject.SetActive(false);

        state = ECellState.NORMAL; // Khởi tạo trạng thái ban đầu là NORMAL
    }

    #endregion

    #region [Override]

    #endregion

    /// <summary>
    /// Thiết lập màu khi trò chơi bắt đầu
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
    /// Đặt lại trạng thái cho ô
    /// </summary>
    public void SetCellState(ECellState stateWantChange) => State = stateWantChange;

    /// <summary>
    /// Thiết lập quân cờ cho ô
    /// </summary>
    public void SetPiece(BasePiece piece) => curPiece = piece;

    /// <summary>
    /// Lấy quân cờ trên ô
    /// </summary>
    public BasePiece GetPiece() => curPiece;

    public void MakeAMove(Cell targetedCell)
    {
        curPiece.Move(targetedCell);
        State = ECellState.NORMAL;
        curPiece = null;
    }
}
