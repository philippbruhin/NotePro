using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotePro.ExtensionMethods;

namespace NotePro.DataStorage
{
    public class ApplicationSession
    {
        private readonly ISession _session;

        public ApplicationSession(ISession session)
        {
            this._session = session;
        }

        public bool DefaultLayout
        {
            get { return _session.GetBoolean("Application.DefaultLayout", true); }
            set { _session.SetBoolean("Application.DefaultLayout", value); }
        }
    }
}
