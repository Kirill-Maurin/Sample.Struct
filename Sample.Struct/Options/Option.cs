using System;
using System.Collections.Generic;

namespace Sample.Struct.Options
{
    public static class Option
    {
        public static Option<T, Option<T>> CanBeNull<T>([CanBeNull]this T reference) where T : class => reference.AsOption();
        public static Option<T, NotNull<T>> AsOption<T>(this NotNull<T> notNull) where T : class => new Option<T, NotNull<T>>(notNull);
        public static Option<T, Option<T>> AsOption<T>([CanBeNull]this T reference) where T : class => new Option<T>(reference).AsOption();
        public static Option<T, Option<T>> AsOption<T>(this Option<T> option) where T : class => new Option<T, Option<T>>(option);
        public static Option<T, TO> AsOption<T, TO>(this Option<T, TO> option) where TO : IOption<T> => option;
        public static Option<T, Null<T>> Null<T>() => Options.Null<T>.Instance;
        public static Option<T, Null<T>> Null<T>(this T _) => Null<T>();

        [CanBeNull]
        public static T AsReference<T>(this Option<T> option) where T : class => option.TryGetValue(out var reference) ? reference : null;
        [CanBeNull]
        public static T AsReference<T>(this Option<T, Option<T>> option) where T : class => option.Unwrap.AsReference();
    }

    public readonly struct Option<T> : IOption<T>, IEquatable<Option<T>> where T : class
    {
        internal Option([CanBeNull]T value) => Value = value;

        public bool TryGetValue(out NotNull<T> value)
        {
            value = new NotNull<T>(Value);
            return HasValue;
        }

        public override bool Equals(object obj) => obj is Option<T> option && Equals(option);
        public override int GetHashCode() => Value?.GetHashCode() ?? 2019994878;
        public override string ToString() => TryGetValue(out var v) ? $"Option {v}" : $"Null<{nameof(T)}>";

        public bool HasValue => Value != null;
        T Value { get; }

        public bool Equals(Option<T> other) => HasValue == other.HasValue && (!HasValue || EqualityComparer<T>.Default.Equals(Value, other.Value));
        public bool Equals(Option<T, Option<T>> other) => Equals(other.Unwrap);
        public static implicit operator Option<T>(T reference) => new Option<T>(reference);
        public static implicit operator Option<T, Option<T>>(Option<T> option) => option.AsOption();

        public static bool operator ==(Option<T> left, Option<T> right) => left.Equals(right);

        public static bool operator !=(Option<T> left, Option<T> right) => !(left == right);
    }

    public readonly struct Option<T, TO> : IOption<T>, IEquatable<Option<T, TO>> where TO : IOption<T>
    {
        public Option(in TO option) => Unwrap = option;

        public bool TryGetValue(out NotNull<T> value) => Unwrap.TryGetValue(out value);

        public override bool Equals(object obj) => obj is Option<T, TO> option && Equals(option);
        public override int GetHashCode() => Unwrap.GetHashCode();
        public override string ToString() => Unwrap.ToString();

        public bool HasValue => Unwrap.HasValue;
        public TO Unwrap { get; }

        public bool Equals(Option<T, TO> other) => Unwrap.Equals(other.Unwrap);
        public bool Equals(TO other) => other.Equals(Unwrap);
        public static implicit operator TO(Option<T, TO> t) => t.Unwrap;

        public static bool operator ==(Option<T, TO> left, Option<T, TO> right) => left.Equals(right);

        public static bool operator !=(Option<T, TO> left, Option<T, TO> right) => !(left == right);
    }
}
