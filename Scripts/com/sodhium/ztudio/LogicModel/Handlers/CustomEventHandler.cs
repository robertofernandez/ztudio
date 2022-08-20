using System.Collections.Generic;

namespace com.sodhium.ztudio.LogicModel.Handlers
{
    public interface CustomEventHandler
    {
        void Execute(Dictionary<string, object> @params);
    }
}
