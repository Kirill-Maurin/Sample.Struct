namespace Sample.Struct.Operator;

public readonly struct Operationable<T, TArg2, TOperator> where TOperator : struct, IOperator<T, TArg2>
{
    private Operationable(T value)
    {
        this.Value = value;
    }

    public T Value { get; }

    public static implicit operator Operationable<T, TArg2, TOperator>(T value)
    {
        return new Operationable<T, TArg2, TOperator>(value);
    }

    public static implicit operator T(Operationable<T, TArg2, TOperator> value)
    {
        return value.Value;
    }

    public override bool Equals(object obj)
    {
        return obj is Operationable<T, TArg2, TOperator> equatable && equatable == this;
    }

    public bool Equals(Operationable<T, TArg2, TOperator> other)
    {
        return this == other;
    }

    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }

    public static Operationable<T, TArg2, TOperator> operator +(Operationable<T, TArg2, TOperator> left,
        Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.Add(left, right);
    }

    public static Operationable<T, TArg2, TOperator> operator +(Operationable<T, TArg2, TOperator> left, TArg2 right)
    {
        var @operator = default(TOperator);
        return @operator.Add(left, right);
    }

    public bool HasValue
    {
        get
        {
            var @operator = default(TOperator);
            return @operator.HasValue(this.Value);
        }
    }

    public static Operationable<T, TArg2, TOperator> operator -(Operationable<T, TArg2, TOperator> value)
    {
        var @operator = default(TOperator);
        return @operator.Negate(value);
    }

    public static Operationable<T, TArg2, TOperator> operator ~(Operationable<T, TArg2, TOperator> value)
    {
        var @operator = default(TOperator);
        return @operator.Not(value);
    }

    public static Operationable<T, TArg2, TOperator> operator |(Operationable<T, TArg2, TOperator> left,
        Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.Or(left, right);
    }

    public static Operationable<T, TArg2, TOperator> operator &(Operationable<T, TArg2, TOperator> left,
        Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.And(left, right);
    }

    public static Operationable<T, TArg2, TOperator> operator ^(Operationable<T, TArg2, TOperator> left,
        Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.Xor(left, right);
    }

    public static explicit operator TArg2(Operationable<T, TArg2, TOperator> value)
    {
        var @operator = default(TOperator);
        return @operator.Convert(value);
    }


    public static Operationable<T, TArg2, TOperator> operator -(Operationable<T, TArg2, TOperator> left,
        Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.Subtract(left, right);
    }

    public static Operationable<T, TArg2, TOperator> operator -(Operationable<T, TArg2, TOperator> left, TArg2 right)
    {
        var @operator = default(TOperator);
        return @operator.Subtract(left, right);
    }

    public static Operationable<T, TArg2, TOperator> operator *(Operationable<T, TArg2, TOperator> left,
        Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.Multiply(left, right);
    }

    public static Operationable<T, TArg2, TOperator> operator *(Operationable<T, TArg2, TOperator> left, TArg2 right)
    {
        var @operator = default(TOperator);
        return @operator.Multiply(left, right);
    }

    public static Operationable<T, TArg2, TOperator> operator /(Operationable<T, TArg2, TOperator> left,
        Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.Divide(left, right);
    }

    public static Operationable<T, TArg2, TOperator> operator /(Operationable<T, TArg2, TOperator> left, TArg2 right)
    {
        var @operator = default(TOperator);
        return @operator.Divide(left, right);
    }

    public static Operationable<T, TArg2, TOperator> operator /(Operationable<T, TArg2, TOperator> left, int right)
    {
        var @operator = default(TOperator);
        return @operator.DivideInt32(left, right);
    }

    public static bool operator ==(Operationable<T, TArg2, TOperator> left, Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.Equal(left, right);
    }

    public static bool operator !=(Operationable<T, TArg2, TOperator> left, Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.NotEqual(left, right);
    }

    public static bool operator >(Operationable<T, TArg2, TOperator> left, Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.GreaterThan(left, right);
    }

    public static bool operator <(Operationable<T, TArg2, TOperator> left, Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.LessThan(left, right);
    }

    public static bool operator >=(Operationable<T, TArg2, TOperator> left, Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.GreaterThanOrEqual(left, right);
    }

    public static bool operator <=(Operationable<T, TArg2, TOperator> left, Operationable<T, TArg2, TOperator> right)
    {
        var @operator = default(TOperator);
        return @operator.LessThanOrEqual(left, right);
    }
}
