using System;
using System.Collections.Generic;

namespace Sample.Struct.Options
{
    public static class Option
    {
        public static Option<T, Option<T>> CanBeNull<T>([CanBeNull]this T reference) where T : class => reference.AsOption();
        public static Option<T, Option<T>> AsOption<T>([CanBeNull]this T reference) where T : class => new Option<T>(reference).AsOption();
        public static Option<T, Option<T>> AsOption<T>(this Option<T> option) where T : class => new Option<T, Option<T>>(option);
        public static Option<T, TO> AsOption<T, TO>(this Option<T, TO> option) where TO : IOption<T> => option;
        public static Option<T, Null<T>> Null<T>() => Options.Null<T>.Instance;
        public static Option<T, Null<T>> Null<T>(this T _) => Null<T>();

        [CanBeNull]
        public static T AsReference<T>(this Option<T> option) where T : class => option.TryGetValue(out var reference) ? reference : null;
        [CanBeNull]
        public static T AsReference<T>(this Option<T, Option<T>> option) where T : class => option.Value.AsReference();
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
        public bool Equals(Option<T, Option<T>> other) => Equals(other.Value);
        public static implicit operator Option<T>(T reference) => new Option<T>(reference);
        public static implicit operator Option<T, Option<T>>(Option<T> option) => option.AsOption();

        public static bool operator ==(Option<T> left, Option<T> right) => left.Equals(right);

        public static bool operator !=(Option<T> left, Option<T> right) => !(left == right);
    }

    public readonly struct Option<T, TOption> : IOption<T>, IEquatable<Option<T, TOption>> where TOption : IOption<T>
    {
        public Option(in TOption option) => Value = option;

        public bool TryGetValue(out NotNull<T> value) => Value.TryGetValue(out value);

        public override bool Equals(object obj) => obj is Option<T, TOption> option && Equals(option);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();

        public bool HasValue => Value.HasValue;
        public TOption Value { get; }

        public bool Equals(Option<T, TOption> other) => Value.Equals(other.Value);
        public bool Equals(TOption other) => other.Equals(Value);
        public static implicit operator TOption(Option<T, TOption> t) => t.Value;

        public static bool operator ==(Option<T, TOption> left, Option<T, TOption> right) => left.Equals(right);

        public static bool operator !=(Option<T, TOption> left, Option<T, TOption> right) => !(left == right);
    }
}
