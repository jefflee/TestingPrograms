namespace TestingPrograms.DarkThreadDuplicatedItems
{
    /// <summary>
    /// 題問：想在陣列挑出連續重複出現的項目，例如要從陣列 [A, B, B, C, X, C, C, B, B, D, D, D] 挑出 [B, B]、[C, C]、[B, B]、[D, D, D] 四個群組。
    /// https://blog.darkthread.net/blog/find-repeated-item-group/?fbclid=IwAR17AGBrS-1WfCA4Ov1sf4QDDJqXq6RjvxNwoaTwjwU2RsOcbmv53tGyp4A
    ///
    /// Joey
    /// https://gist.github.com/hatelove/355b0740f9f76d1187dc61d6bb21b4fa?fbclid=IwAR1R9mfYQ64Fs4UwB_BiY-Wo_RQBemFBaH6hTIFmx-A4TqX1KEd5CffkjYE
    /// </summary>
    internal class DuplicateItems
    {

        public IEnumerable<IEnumerable<T>> FindDuplicatedItems<T>(IEnumerable<T> collection, IEqualityComparer<T> equalityComparer)
        {
            using var enumerator = collection.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                yield break;
            }

            var dupList = new List<T> { enumerator.Current };
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (!equalityComparer.Equals(current, dupList.First()))
                {
                    if (dupList.Count > 1)
                    {
                        yield return dupList;
                    }
                    dupList = new List<T>();
                }

                dupList.Add(current);
            }

            if (dupList.Count > 1)
            {
                yield return dupList;
            }
        }
    }
}
