
using Autodesk.Revit.DB;
using System;

namespace FamiliesUpdater.Exeptions
{
    public static class DocumentExtensions
    {
        public static bool Do(this Document doc, Func<bool> func)
        {
            bool result = false;

            try
            {
                using (var tx = new Transaction(doc, $"{func.Method.Name}"))
                {
                    if (tx.Start() == TransactionStatus.Started)
                    {
                        result = (bool)(func?.Invoke());
                        tx.Commit();
                    }
                }
            }
            catch
            {
               
            }

            return result;
        }

        public static bool Do(this Document doc, Action action)
        {
            try
            {
                using (Transaction tx = new Transaction(doc, $"{action.Method.Name}"))
                {
                    if (tx.Start() == TransactionStatus.Started)
                    {
                        action?.Invoke();
                        tx.Commit();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}