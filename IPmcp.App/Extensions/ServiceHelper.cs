using IPmcp.App.Exceptions;
using LinqToDB;

namespace IPmcp.App.Extensions;

internal static class ServiceHelper
{
    internal static async Task<T> ExecuteAsync<T>(Func<Task<T>> action)
    {
        try
        {
            return await action();
        }
        catch (OperationCanceledException) { throw; }
        catch (Exception ex) when (ex is LinqToDBException or System.Data.Common.DbException)
        {
            throw new DatabaseException(ex);
        }
        catch (Exception ex)
        {
            throw new DatabaseException(ex.Message, ex);
        }
    }
}
