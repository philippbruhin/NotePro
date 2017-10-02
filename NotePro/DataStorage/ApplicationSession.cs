using Microsoft.AspNetCore.Http;
using NotePro.ExtensionMethods;
using NotePro.Models;

namespace NotePro.DataStorage
{
    public class ApplicationSession
    {
        private readonly ISession _session;

        public ApplicationSession(ISession session)
        {
            this._session = session;
            _session.GetBoolean("Application.DefaultLayout", true);
        }

        public bool DefaultLayout
        {
            get { return _session.GetBoolean("Application.DefaultLayout", true); }
            set { _session.SetBoolean("Application.DefaultLayout", value); }
        }
    }
}
