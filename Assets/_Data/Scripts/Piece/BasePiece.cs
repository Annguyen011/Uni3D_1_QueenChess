using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePiece : MonoBehaviour
{
    #region [Elements]

    [Header("# Spawn infos")]
    public PieceInfo pieceInfo; // Thông tin về quân cờ
    [SerializeField] protected EPlayer player; // Người chơi sở hữu quân cờ

    [Header("# Cell infos")]
    [SerializeField] protected List<Cell> targetCell; // Danh sách các ô mục tiêu cho quân cờ

    #endregion


    // Thiết lập thông tin của quân cờ
    public void SetPieceInfo(PieceInfo pieceInfo)
    {
        this.pieceInfo = pieceInfo;
    }

    // Phương thức di chuyển quân cờ, sẽ được ghi đè trong các lớp con
    public abstract void Move();

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
    public void BeUnselected() => targetCell.ForEach(item =>
    { item.SetCellState(ECellState.NORMAL); });

    // Kiểm tra xem ô đã được chọn có chứa quân cờ hay không
    protected BasePiece CheckCellHasPiece(int x, int y) =>
        ChessBoard.instance.Cells[x][y].curPiece;
}
