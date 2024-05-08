using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePiece : MonoBehaviour
{
    #region [Elements]

    [Header("# Spawn infos")]
    public PieceInfo pieceInfo; // Thông tin về quân cờ
    public EPlayer player; // Người chơi sở hữu quân cờ

    [Header("# Cell infos")]
    public Cell curCell;
    [SerializeField] protected List<Cell> targetCell; // Danh sách các ô mục tiêu cho quân cờ
    protected int setPosCnt = 0;
    #endregion


    // Thiết lập thông tin của quân cờ
    public void SetPieceInfo(PieceInfo pieceInfo, Cell cell)
    {
        this.pieceInfo = pieceInfo;

        SetNewPosition(cell);
    }

    // Phương thức di chuyển quân cờ, sẽ được ghi đè trong các lớp con
    public virtual void Move(Cell targetedCell)
    {
        SetNewPosition(targetedCell);

        BeUnselected();

        GameManager.Instance.SwitchTurn();
    }

    public virtual void Attack(Cell targetedCell)
    {
        targetedCell.curPiece.BeAttackBy(this);
        curCell.SetCellState(ECellState.NORMAL);
        SetNewPosition(targetedCell);
        BeUnselected();
        GameManager.Instance.SwitchTurn();
    }

    // Phương thức được gọi khi quân cờ được chọn, hiển thị các nước có thể đi
    public virtual void BeSelected()
    {
            // Hiển thị các ô mục tiêu cho quân cờ tương ứng với từng người chơi
            switch (player)
            {
                case EPlayer.BLACK:
                    BeSlectedBlack();
                    break;
                case EPlayer.WHITE:
                    BeSlectedWhite();
                    break;
            }

        targetCell.ForEach(item => { item.SetCellState(ECellState.TARGET); });
    }

    // Thêm một ô mục tiêu vào danh sách các ô mục tiêu
    protected void AddCellOnCellTarget(int x, int y)
    {
        targetCell.Add(ChessBoard.instance.Cells[x][y]);
    }

    // Phương thức trừu tượng được gọi khi quân cờ đen được chọn
    protected abstract void BeSlectedBlack();

    // Phương thức trừu tượng được gọi khi quân cờ trắng được chọn
    protected abstract void BeSlectedWhite();

    // Phương thức loại bỏ trạng thái chọn và mục tiêu của quân cờ
    public void BeUnselected()
    {
        targetCell.ForEach(item =>
            { item.SetCellState(ECellState.NORMAL); });

        targetCell.Clear();
    }
    // Kiểm tra xem ô đã được chọn có chứa quân cờ hay không
    protected BasePiece CheckCellHasPiece(int x, int y) =>
        ChessBoard.instance.Cells[x][y].curPiece;

    protected void SetNewPosition(Cell newCell)
    {
        setPosCnt++;

        if (setPosCnt > 1)
        {
            curCell.curPiece = null;
        }

        newCell.curPiece = this;
        curCell = newCell;

        pieceInfo.x = (int)newCell.location.x;
        pieceInfo.y = (int)newCell.location.y;

        transform.position = ChessBoard.instance.Cells[this.pieceInfo.x][this.pieceInfo.y].transform.position;
    }

    public virtual void BeAttackBy(BasePiece enemy)
    {
        if(gameObject.TryGetComponent<PKing>(out PKing _))
        {
            GameManager.Instance.GameOver();
            return;
        }

        Destroy(gameObject);
        curCell.curPiece = null;
    }
}
