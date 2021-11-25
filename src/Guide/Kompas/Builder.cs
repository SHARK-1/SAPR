using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KompasAPI7;


namespace Kompas
{
    public class Builder
    {
        private KompasConnector _kompasConnector;
        public Builder(KompasConnector kompasConnector)
        {
            _kompasConnector = kompasConnector;
        }

        public void CreateModel()
        {

        }
    }
}
