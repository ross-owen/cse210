namespace Learning03;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = _numerator == 0 ? 0 : 1;
    }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0 && numerator != 0)
        {
            throw new ArgumentException("denominator cannot be zero");
        }

        _numerator = numerator;
        _denominator = denominator;
    }

    public int Numerator
    {
        get => _numerator;
        set
        {
            _numerator = value;
            if (value == 0)
            {
                _numerator = 0;
            }
        }
    }

    public int Denominator
    {
        get => _denominator;
        set
        {
            if (value == 0)
            {
                throw new ArgumentException("denominator cannot be zero");
            }

            _denominator = value;
        }
    }

    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}