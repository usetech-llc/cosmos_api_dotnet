using System.Collections.Generic;

namespace CosmosApi.Models
{
    public interface ITx
    {
        IList<IMsg> GetMsgs();
    }
}