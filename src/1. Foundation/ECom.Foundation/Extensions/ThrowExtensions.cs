using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ECom.Foundation.Extensions;

public static class ThrowExtensions
{
  public static void EnsureNotNull(this object? value, string message) {
    if (value is null)
      throw new ArgumentNullException(message);
  }

  public static void EnsureNotNull(this object? value) {
    if (value is null)
      throw new ArgumentNullException();
  }

  public static void EnsureNotSame<T>(this T value, T other, string message) {
    if (value.Equals(other))
      throw new ArgumentException(message);
  }

  public static void EnsureNotSame<T>(this T value, T other) {
    if (value.Equals(other))
      throw new ArgumentException();
  }

  public static void EnsureSame<T>(this T value, T other, string message) {
    if (!value.Equals(other))
      throw new ArgumentException(message);
  }

  public static void EnsureSame<T>(this T value, T other) {
    if (!value.Equals(other))
      throw new ArgumentException();
  }

  public static void EnsureNotNullOrEmpty(this string? value, string message) {
    if (string.IsNullOrEmpty(value))
      throw new ArgumentException(message);
  }

  public static void EnsureNotNullOrEmpty(this string? value) {
    if (string.IsNullOrEmpty(value))
      throw new ArgumentException();
  }

  public static void EnsureNotNullOrWhiteSpace(this string? value, string message) {
    if (string.IsNullOrWhiteSpace(value))
      throw new ArgumentException(message);
  }

  public static void EnsureNotNullOrWhiteSpace(this string? value) {
    if (string.IsNullOrWhiteSpace(value))
      throw new ArgumentException();
  }

  public static void EnsureNotNullOrEmpty<T>(this IEnumerable<T>? value, string message) {
    if (value is null || !value.Any())
      throw new ArgumentException(message);
  }

  public static void EnsureNotNullOrEmpty<T>(this IEnumerable<T>? value) {
    if (value is null || !value.Any())
      throw new ArgumentException();
  }

  public static void EnsureOneElement<T>(this IEnumerable<T>? value, string message) {
    if (value is null || !value.Any() || value.Count() > 1)
      throw new ArgumentException(message);
  }


  public static void EnsureOneElement<T>(this IEnumerable<T>? value) {
    if (value is null || !value.Any() || value.Count() > 1)
      throw new ArgumentException();
  }


  public static void EnsureOneElementAndNotNull<T>(this IEnumerable<T>? value, string message) {
    if (value is null || !value.Any() || value.Count() > 1 || value.First() is null)
      throw new ArgumentException(message);
  }

  public static void EnsureOneElementAndNotNull<T>(this IEnumerable<T>? value) {
    if (value is null || !value.Any() || value.Count() > 1 || value.First() is null)
      throw new ArgumentException();
  }
}