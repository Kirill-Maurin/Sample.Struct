using System;

namespace Sample.Struct
{
    public static class AAA
    {
        public static ArrangeResult<T> Arrange<T>(this T @object) => new ArrangeResult<T>(@object);

        public static ActResult<T> Act<T>(this ArrangeResult<T> arrange, Action<T> act)
        {
            act(arrange.Object);
            return new ActResult<T>(arrange.Object);
        }

        public static ActResult<TResult> Act<T, TResult>(this ArrangeResult<T> arrange, Func<T, TResult> act)
            => new ActResult<TResult>(act(arrange.Object));

        public static void Assert<T>(this ActResult<T> act, Action<T> assert)
            => assert(act.Object);

        public readonly struct ArrangeResult<T>
        {
            internal ArrangeResult(T @object) => Object = @object;
            internal T Object { get; }
        }

        public readonly struct ActResult<T>
        {
            internal ActResult(T @object) => Object = @object;
            internal T Object { get; }
        }
    }
}