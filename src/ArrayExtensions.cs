namespace CollectionExtensions;

public static class ArrayExt
{
    public static T[] FindAll<T>(this T[] array, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentNullException.ThrowIfNull(predicate);

        var counter = 0;
        var newArray = new T[array.Length];
        for (var i = 0; i < array.Length; i++)
        {
            if (predicate(array[i]) is false)
            {
                continue;
            }

            newArray[counter] = array[i];
            counter++;
        }

        return newArray.AsSpan(0, counter).ToArray();
    }

    public static TOutput[] ConvertAll<TInput, TOutput>(this TInput[] array, Converter<TInput, TOutput> converter)
    {
        return Array.ConvertAll(array, converter);
    }

    public static T? Find<T>(this T[] array, Predicate<T> predicate)
    {
        return Array.Find(array, predicate);
    }

    public static bool Exists<T>(this T[] array, Predicate<T> predicate)
    {
        return Array.Exists(array, predicate);
    }

    public static bool TrueForAll<T>(this T[] array, Predicate<T> predicate)
    {
        return Array.TrueForAll(array, predicate);
    }
}
