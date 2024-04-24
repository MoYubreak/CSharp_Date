using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class Date
{
    private int _year;
    private int _month;
    private int _day;
    public Date(int year = 0, int month = 0, int day = 0)
    {
        _year = year;
        _month = month;
        _day = day;
    }

    public Date(ref Date date)
    {
        _year = date._year;
        _month = date._month;
        _day = date._day;
    }
    #region
    //public int Year
    //{
    //    get;
    //    private set;
    //}

    //public int Month
    //{
    //    get;
    //    set;
    //}

    //public int Day
    //{
    //    get;
    //    set;
    //}
    #endregion


    public void print()
    {
        Console.WriteLine(_year + "年" + _month + "月" + _day + "日");
    }

    public int GetMonthDay()
    {
        int[] array = new int[]{ 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if(_month == 2 && ((_year%4 == 0 && _year%100 != 0) || (_year%400 == 0)))
        {
            return 29;
        }
        return array[_month];
    }
    public static bool operator>(Date date1 , Date date2)
    {
        if(date1._year > date2._year)
        {
            return true;
        }
        else if(date1._year == date2._year)
        {
            if(date1._month > date2._month)
            {
                return true;
            }
            else if(date1._month == date2._month)
            {
                 if(date1._day > date2._day)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public static bool operator <(Date date1, Date date2)
    {
        return !(date1 > date2) && !(date1 == date2);
    }
    public static bool operator >=(Date date1, Date date2)
    {
        return !(date1 < date2);
    }
    public static bool operator <=(Date date1, Date date2)
    {
        return !(date1 > date2);
    }
    public static bool operator ==(Date date1, Date date2)
    {
        return date1._year == date2._year && date1._month == date2._month && date1._day == date2._day;
    }
    public static bool operator !=(Date date1, Date date2)
    {
        return !(date1 == date2);
    }

    public static Date operator+(Date date1, int day)
    {
        Date date = new Date(ref date1);
        date._day += day; 
        while(date._day > date.GetMonthDay())
        {
            date._day -= date.GetMonthDay();
            date._month++;
            if(date._month == 13)
            {
                date._month = 1;
                date._year++;
            }
        }
        return date;
    }

    public static Date operator -(Date date1, int day)
    {
        Date date = new Date(ref date1);
        date._day -= day;
        while(date._day < 0)
        {
            date._month--;
            if(date._month == 0)
            {
                date._month = 12;
                date._year--;
            }
            date._day += date.GetMonthDay();
        }
        return date;
    }

    public static int operator-(Date date1 , Date date2)
    {
        Date min = new Date(ref date1);
        Date max = new Date(ref date2);
        int n = 0;
        int fal = 1;
        if(min > max)
        {
            min = max;
            max = date1;
            fal = -1;
        }
        while(min < max)
        {
            min = min + 1;
            n++;
        }
        return n * fal;
    }

    public static Date operator++(Date date)
    {
        Date date1 = new Date(ref date);
        date1 = date1 + 1;
        return date1;
    }

    public static Date operator --(Date date)
    {
        Date date1 = new Date(ref date);
        date1 = date1 - 1;
        return date1;
    }
    ~Date()
    { }
}



namespace Date_4_23
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Date date = new Date(2024, 4, 24);
            Date date1 = date - 2;
            date1 = date1 + 1;
            date1 = date1 + 3;
            date1.print();
        }
    }
}
