using System.Collections.Generic;
using UnityEngine;


public class PKnight : BasePiece
{

    #region [Elements]



    #endregion


    #region [Components]



    #endregion

    #region [Unity Methods]



    #endregion

    #region [Override]


    public override void BeSelected()
    {
        List<Vector2> vec = GetTargetalbeLocation();

        foreach (Vector2 v in vec)
        {
            Cell c = ChessBoard.instance.Cells[(int)v.x][(int)v.y];
            if (c.curPiece == null) 
            {
                targetCell.Add(c);
            }
            else if(c.curPiece.player != GameManager.Instance.Player)
            {
                targetCell.Add(c);
            }
        }

        base.BeSelected();
    }

    protected override void BeSlectedWhite()
    {

    }

    protected override void BeSlectedBlack()
    {
    }

    private List<Vector2> GetTargetalbeLocation()
    {
        List<Vector2> location = new List<Vector2>();

        location.Add(InBound(new Vector2(pieceInfo.x + 2, pieceInfo.y - 1)));
        location.Add(InBound(new Vector2(pieceInfo.x + 2, pieceInfo.y + 1)));
        location.Add(InBound(new Vector2(pieceInfo.x - 2, pieceInfo.y - 1)));
        location.Add(InBound(new Vector2(pieceInfo.x - 2, pieceInfo.y + 1)));
        location.Add(InBound(new Vector2(pieceInfo.x + 1, pieceInfo.y + 2)));
        location.Add(InBound(new Vector2(pieceInfo.x - 1, pieceInfo.y + 2)));
        location.Add(InBound(new Vector2(pieceInfo.x - 1, pieceInfo.y - 2)));
        location.Add(InBound(new Vector2(pieceInfo.x + 1, pieceInfo.y - 2)));

        location.RemoveAll(x => x == new Vector2(8, 8));

        return location;
    }

    private Vector2 InBound(Vector2 vector2)
    {
        if (vector2.x >= 0 && vector2.y >= 0 && vector2.x <= 7 && vector2.y <= 7)
        {
            return vector2;
        }
        return new(8, 8);
    }

    #endregion

}
