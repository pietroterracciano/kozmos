using System;
using System.Collections;
using Kozmos.Helpers.Collectibles;
using Kozmos.Helpers.Exceptions;

namespace Kozmos.Helpers.Cursors
{
    public static class KozmosIEnumeratorHelperBase<T>
        where T : IEnumerator
    {
        //public static Type GetElementType(T source)
        //{
        //    KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
        //    Type t = KozmosTypeHelper.GetType(source);
        //    if(t.IsArray) return KozmosArrayHelper.GetElementType(source);
        //    Type? t0 = KozmosTypeHelper.TryGetGenericTypeArguments();
        //}


        //public static Type? GetElementType<U>()
        //    where U : IEnumerator
        //{
        //    return GetElementType(TypeUtils.Get<T>());
        //}
        //public static Type? GetElementType(Type? t)
        //{
        //    if (Is(t))
        //        return TypeUtils.GetGenericTypeArgument(t, 0);
        //    else
        //        return null;
        //}
    }
}

