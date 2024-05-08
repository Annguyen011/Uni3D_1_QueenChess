using UnityEngine;

public class PBishop : BasePiece
{
    #region [Unity Methods]

    // Phương thức được gọi khi quân cờ được chọn
    public override void BeSelected()
    {
        // Duyệt các ô mục tiêu theo các hướng phải trên, phải dưới, trái trên và trái dưới
        CheckDiagonal(Vector2.right, Vector2.up); // Phải trên
        CheckDiagonal(Vector2.right, Vector2.down); // Phải dưới
        CheckDiagonal(Vector2.left, Vector2.up); // Trái trên
        CheckDiagonal(Vector2.left, Vector2.down); // Trái dưới

        // Gọi phương thức BeSelected của lớp cơ sở để hiển thị các ô mục tiêu
        base.BeSelected();
    }

    #endregion

    #region [Helper Methods]

    // Phương thức kiểm tra các ô mục tiêu theo đường chéo
    private void CheckDiagonal(Vector2 directionX, Vector2 directionY)
    {
        Vector2 vec = new Vector2(pieceInfo.x, pieceInfo.y);

        // Duyệt qua các ô theo hướng directionX và directionY
        while (true)
        {
            vec += directionX; // Di chuyển theo hướng directionX
            vec += directionY; // Di chuyển theo hướng directionY

            // Kiểm tra xem ô mới có nằm trong biên giới của bàn cờ không
            if (Helper.CheckBound(vec))
            {
                Cell cell = ChessBoard.instance.Cells[(int)vec.x][(int)vec.y];

                // Nếu ô có quân cờ
                if (cell.curPiece)
                {
                    // Nếu quân cờ đó không thuộc về người chơi hiện tại
                    if (cell.curPiece.player != GameManager.Instance.Player)
                    {
                        targetCell.Add(cell); // Thêm ô vào danh sách các ô mục tiêu
                    }
                    break; // Dừng duyệt
                }

                targetCell.Add(cell); // Thêm ô vào danh sách các ô mục tiêu
            }
            else
            {
                break; // Nếu ô mới nằm ngoài biên giới của bàn cờ, dừng duyệt
            }
        }
    }

    #endregion

    #region [Override Methods]

    // Phương thức được ghi đè để xử lý khi quân cờ trắng được chọn
    protected override void BeSlectedWhite()
    {
        // Không cần thực hiện gì đặc biệt với quân cờ trắng
    }

    // Phương thức được ghi đè để xử lý khi quân cờ đen được chọn
    protected override void BeSlectedBlack()
    {
        // Không cần thực hiện gì đặc biệt với quân cờ đen
    }

    #endregion
}
