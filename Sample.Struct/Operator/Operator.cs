using O = MiscUtil.Operator;

namespace Sample.Struct.Operator;

using Summators;

public struct Operator<T, TArg2> : ISummator<T>, ISummator<T, TArg2>, IOperator<T, TArg2>
{
    /// <summary>
    ///     Indicates if the supplied value is non-null,
    ///     for reference-types or Nullable&lt;T&gt;
    /// </summary>
    /// <returns>True for non-null values, else false</returns>
    public bool HasValue(T value)
    {
        return O.HasValue(value);
    }

    /// <summary>
    ///     Increments the accumulator only
    ///     if the value is non-null. If the accumulator
    ///     is null, then the accumulator is given the new
    ///     value; otherwise the accumulator and value
    ///     are added.
    /// </summary>
    /// <param name="accumulator">The current total to be incremented (can be null)</param>
    /// <param name="value">The value to be tested and added to the accumulator</param>
    /// <returns>
    ///     True if the value is non-null, else false - i.e.
    ///     "has the accumulator been updated?"
    /// </returns>
    public bool AddIfNotNull(ref T accumulator, T value)
    {
        return O.AddIfNotNull(ref accumulator, value);
    }

    /// <summary>
    ///     Evaluates unary negation (-) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T Negate(T value)
    {
        return O.Negate(value);
    }

    /// <summary>
    ///     Evaluates bitwise not (~) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T Not(T value)
    {
        return O.Not(value);
    }

    /// <summary>
    ///     Evaluates bitwise or (|) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T Or(T value1, T value2)
    {
        return O.Or(value1, value2);
    }

    /// <summary>
    ///     Evaluates bitwise and (&amp;) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T And(T value1, T value2)
    {
        return O.And(value1, value2);
    }

    /// <summary>
    ///     Evaluates bitwise xor (^) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T Xor(T value1, T value2)
    {
        return O.Xor(value1, value2);
    }

    /// <summary>
    ///     Performs a conversion between the given types; this will throw
    ///     an InvalidOperationException if the type T does not provide a suitable cast, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this cast.
    /// </summary>
    public TArg2 Convert(T value)
    {
        return O.Convert<T, TArg2>(value);
    }

    /// <summary>
    ///     Evaluates binary addition (+) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T Add(T value1, T value2)
    {
        return O.Add(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary addition (+) for the given type(s); this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T Add(T value1, TArg2 value2)
    {
        return O.AddAlternative(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary subtraction (-) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T Subtract(T value1, T value2)
    {
        return O.Subtract(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary subtraction(-) for the given type(s); this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T Subtract(T value1, TArg2 value2)
    {
        return O.SubtractAlternative(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary multiplication (*) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T Multiply(T value1, T value2)
    {
        return O.Multiply(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary multiplication (*) for the given type(s); this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T Multiply(T value1, TArg2 value2)
    {
        return O.MultiplyAlternative(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary division (/) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T Divide(T value1, T value2)
    {
        return O.Divide(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary division (/) for the given type(s); this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public T Divide(T value1, TArg2 value2)
    {
        return O.DivideAlternative(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary equality (==) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public bool Equal(T value1, T value2)
    {
        return O.Equal(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary inequality (!=) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public bool NotEqual(T value1, T value2)
    {
        return O.NotEqual(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary greater-than (&gt;) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public bool GreaterThan(T value1, T value2)
    {
        return O.GreaterThan(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary less-than (&lt;) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public bool LessThan(T value1, T value2)
    {
        return O.LessThan(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary greater-than-on-eqauls (&gt;=) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public bool GreaterThanOrEqual(T value1, T value2)
    {
        return O.GreaterThanOrEqual(value1, value2);
    }

    /// <summary>
    ///     Evaluates binary less-than-or-equal (&lt;=) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    public bool LessThanOrEqual(T value1, T value2)
    {
        return O.LessThanOrEqual(value1, value2);
    }

    /// <summary>
    ///     Evaluates integer division (/) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    /// <remarks>
    ///     This operation is particularly useful for computing averages and
    ///     similar aggregates.
    /// </remarks>
    public T DivideInt32(T value, int divisor)
    {
        return O.DivideInt32(value, divisor);
    }
}
