using UnityEngine;

public class PKing : BasePiece
{
    #region [Unity Methods]

    // Phương thức được ghi đè để xử lý khi quân vua được chọn
    public override void BeSelected()
    {
        // Kiểm tra các ô xung quanh quân vua và thêm vào danh sách các ô mục tiêu
        CheckSurroundingCells(Vector2.up); // Ô phía trên
        CheckSurroundingCells(Vector2.down); // Ô phía dưới
        CheckSurroundingCells(Vector2.right); // Ô bên phải
        CheckSurroundingCells(Vector2.left); // Ô bên trái
        CheckSurroundingCells(Vector2.up + Vector2.right); // Ô đường chéo phải trên
        CheckSurroundingCells(Vector2.up + Vector2.left); // Ô đường chéo trái trên
        CheckSurroundingCells(Vector2.down + Vector2.right); // Ô đường chéo phải dưới
        CheckSurroundingCells(Vector2.down + Vector2.left); // Ô đường chéo trái dưới

        // Hiển thị các ô mục tiêu
        base.BeSelected();
    }

    protected override void BeSlectedBlack()
    {
    }

    protected override void BeSlectedWhite()
    {
    }

    #endregion

    #region [Helper Methods]

    // Phương thức kiểm tra các ô xung quanh quân vua và thêm vào danh sách các ô mục tiêu
    private void CheckSurroundingCells(Vector2 direction)
    {
        Vector2 vec = new Vector2(pieceInfo.x, pieceInfo.y) + direction;

        // Kiểm tra xem ô mới có nằm trong biên giới của bàn cờ không
        if (Helper.CheckBound(vec))
        {
            Cell cell = ChessBoard.instance.Cells[(int)vec.x][(int)vec.y];

            // Nếu ô không có quân cờ hoặc có quân cờ của đối thủ
            if (!cell.curPiece || cell.curPiece.player != GameManager.Instance.Player)
            {
                targetCell.Add(cell); // Thêm ô vào danh sách các ô mục tiêu
            }
        }
    }

    #endregion

    #region [Override Methods]

    #endregion
}
