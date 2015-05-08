using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsoBackup.Configuration
{
    class VsoConfiguration : ConfigurationSection, IVsoConfiguration
    {
        [ConfigurationProperty("ApiUsername", IsRequired = true)]
        public string ApiUsername
        {
            get { return this["ApiUsername"].ToString(); }
        }

        [ConfigurationProperty("ApiPassword", IsRequired = true)]
        public string ApiPassword
        {
            get { return this["ApiPassword"].ToString(); }
        }
       

        [ConfigurationProperty("AllRepositoriesUrl", IsRequired = true)]
        public string AllRepositoriesUrl
        {
            get { return this["AllRepositoriesUrl"].ToString(); }
        }


        


    }
}
