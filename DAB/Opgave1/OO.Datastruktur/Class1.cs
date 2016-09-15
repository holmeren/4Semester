using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO.Datastruktur
{
    public class Context
    {

    }
}

public class ItemX
{
    private int Val1X;
    private string Val2X;
    private ItemY _itY;
    public List<ItemX> ItX;

    public ItemX(ItemY itY)
    {
        _itY = itY;
    }

    public void AddX(int val1, string val2)
    {
        Val1X = val1;
        Val2X = val2;
        ItX.Add(this);
    }
}

public class ItemY
{
    private int Val1Y;
    private string Val2Y;
    private ItemX _itX;
    public List<ItemY> ItY;

    public ItemY(ItemX itx)
    {
        _itX = itx;
    }

    public void AddY(int val1, string val2)
    {
        Val1Y = val1;
        Val2Y = val2;
        ItY.Add(this);
    }


}

public class Context
{
    private ItemX _itX;
    private ItemY _itY;

    public Context(ItemX itX, ItemY itY)
    {
        _itX = itX;
        _itY = itY;
    }
}