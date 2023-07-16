namespace Sample.Struct.Operator;

public interface IOperator<T, TArg2>
{
    /// <summary>
    ///     Indicates if the supplied value is non-null,
    ///     for reference-types or Nullable&lt;T&gt;
    /// </summary>
    /// <returns>True for non-null values, else false</returns>
    bool HasValue(T value);

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
    bool AddIfNotNull(ref T accumulator, T value);

    /// <summary>
    ///     Evaluates unary negation (-) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T Negate(T value);

    /// <summary>
    ///     Evaluates bitwise not (~) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T Not(T value);

    /// <summary>
    ///     Evaluates bitwise or (|) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T Or(T value1, T value2);

    /// <summary>
    ///     Evaluates bitwise and (&amp;) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T And(T value1, T value2);

    /// <summary>
    ///     Evaluates bitwise xor (^) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T Xor(T value1, T value2);

    /// <summary>
    ///     Performs a conversion between the given types; this will throw
    ///     an InvalidOperationException if the type T does not provide a suitable cast, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this cast.
    /// </summary>
    TArg2 Convert(T value);

    /// <summary>
    ///     Evaluates binary addition (+) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T Add(T value1, T value2);

    /// <summary>
    ///     Evaluates binary addition (+) for the given type(s); this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T Add(T value1, TArg2 value2);

    /// <summary>
    ///     Evaluates binary subtraction (-) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T Subtract(T value1, T value2);

    /// <summary>
    ///     Evaluates binary subtraction(-) for the given type(s); this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T Subtract(T value1, TArg2 value2);

    /// <summary>
    ///     Evaluates binary multiplication (*) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T Multiply(T value1, T value2);

    /// <summary>
    ///     Evaluates binary multiplication (*) for the given type(s); this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T Multiply(T value1, TArg2 value2);

    /// <summary>
    ///     Evaluates binary division (/) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T Divide(T value1, T value2);

    /// <summary>
    ///     Evaluates binary division (/) for the given type(s); this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    T Divide(T value1, TArg2 value2);

    /// <summary>
    ///     Evaluates binary equality (==) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    bool Equal(T value1, T value2);

    /// <summary>
    ///     Evaluates binary inequality (!=) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    bool NotEqual(T value1, T value2);

    /// <summary>
    ///     Evaluates binary greater-than (&gt;) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    bool GreaterThan(T value1, T value2);

    /// <summary>
    ///     Evaluates binary less-than (&lt;) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    bool LessThan(T value1, T value2);

    /// <summary>
    ///     Evaluates binary greater-than-on-eqauls (&gt;=) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    bool GreaterThanOrEqual(T value1, T value2);

    /// <summary>
    ///     Evaluates binary less-than-or-equal (&lt;=) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    bool LessThanOrEqual(T value1, T value2);

    /// <summary>
    ///     Evaluates integer division (/) for the given type; this will throw
    ///     an InvalidOperationException if the type T does not provide this operator, or for
    ///     Nullable&lt;TInner&gt; if TInner does not provide this operator.
    /// </summary>
    /// <remarks>
    ///     This operation is particularly useful for computing averages and
    ///     similar aggregates.
    /// </remarks>
    T DivideInt32(T value, int divisor);
}