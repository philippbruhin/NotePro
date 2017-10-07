using Microsoft.AspNetCore.Http;
using NotePro.ExtensionMethods;

namespace NotePro.DataStorage
{
    public class ApplicationSession
    {
        private readonly ISession session;

        public ApplicationSession(ISession session)
        {
            this.session = session;
            this.session.GetBoolean("Application.DefaultLayout", true);
        }

        public bool DefaultLayout
        {
            get { return session.GetBoolean("Application.DefaultLayout", true); }
            set { session.SetBoolean("Application.DefaultLayout", value); }
        }
    }
}
