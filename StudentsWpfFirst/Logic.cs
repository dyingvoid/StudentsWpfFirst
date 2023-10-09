using System;
using System.Windows.Input;

namespace StudentsWpfFirst;

public class Logic
{
    private decimal _price;

    private decimal _discount;
    
    public Logic()
    {
    }

    public bool IsNegative()
    {
        return Math.Sign(_price) == 1 && Math.Sign(_discount) == 1;
    }
}